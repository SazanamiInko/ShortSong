using BLayer.DataModel;
using FLayer;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace ShortSong.ViewModels
{
    /// <summary>
    /// 短歌検索ビューモデル
    /// </summary>
    public class ShortSongListViewModel : ComponentBase
    {
        #region プロパティ

        /// <summary>
        /// キーワード
        /// </summary>
        [Parameter]
        public string KeyWord { get; set; }

        /// <summary>
        /// 短歌一覧
        /// </summary>
        public List<ShortSongSimple> ShortSongs { get; set; }
        #endregion

        #region サービス

        /// <summary>
        /// ダイアログ
        /// </summary>
        [Inject]
        public IMatDialogService MatDialogService { get; set; }

        [Inject]
        protected NavigationManager NavManager { get; set; }

       

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ShortSongListViewModel()
        {
            this.ShortSongs = new List<ShortSongSimple>();
        }
        #endregion

        #region イベント

        /// <summary>
        /// 検索イベント
        /// </summary>
        public async void OnSearch()
        {
            Search();

            if (ShortSongs.Count == 0)
            {
                await MatDialogService.AlertAsync("短歌がありませんでした。");
            }
        }

        /// <summary>
        /// 削除イベント
        /// </summary>
        /// <param name="id"></param>
        public async void OnDelete(long id)
        {
            var result = await MatDialogService.ConfirmAsync("短歌を削除していいですか?");

            if (result)
            {
                this.Delete(id);
                this.Search();
            }
        }

        /// <summary>
        /// 編集画面へ
        /// </summary>
        /// <param name="id"></param>
        public void OnEdit(long id)
        {
            NavManager.NavigateTo("/ShortSongEdit/" + id.ToString());
        }

        #endregion

        #region メソッド

        /// <summary>
        /// 検索
        /// </summary>
        public void Search()
        {
            ShortSongs.Clear();

            ShortSongs.AddRange(FrontAPI.GetShortSongs(KeyWord));
        }

        /// <summary>
        /// 短歌削除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id)
        {
            ShortSongs.Clear();
            FrontAPI.DeleteShortSong(id);
        }

        #endregion

    }
}
