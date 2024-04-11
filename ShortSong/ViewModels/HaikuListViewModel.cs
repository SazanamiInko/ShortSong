using FLayer;
using Interfaces.DataModels;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using ShortSong.Common;

namespace ShortSong.ViewModels
{
    /// <summary>
    /// 俳句リストビューモデル
    /// </summary>
    public class HaikuListViewModel : ComponentBase
    {
        #region プロパティ

        /// <summary>
        /// キーワード
        /// </summary>
        [Parameter]
        public string KeyWord { get; set; }

        /// <summary>
        /// お気に入り一覧
        /// </summary>
        public List<IHaikuIndexDataModel> Haikus { get; set; }

        #endregion

        #region サービス

        /// <summary>
        /// ダイアログ
        /// </summary>
        [Inject]
        public IMatDialogService MatDialogService { get; set; }

        /// <summary>
        /// ナビ
        /// </summary>
        [Inject]
        protected NavigationManager NavManager { get; set; }


        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HaikuListViewModel()
        {
            this.Haikus = new List<IHaikuIndexDataModel>();
        }

        #endregion

        #region イベント
        /// <summary>
        /// 検索
        /// </summary>
        public async void OnSearch()
        {

            Search();

            if (Haikus.Count == 0)
            {
                await MatDialogService.AlertAsync("俳句がありませんでした。");
            }
        }

        /// <summary>
        /// 削除
        /// </summary>
        /// <param name="id"></param>
        public async void OnDelete(long id)
        {
            var result = await MatDialogService.ConfirmAsync("俳句を削除していいですか?");

            if (result)
            {
                this.Delete(id);
                this.Search();
            }
            this.StateHasChanged();
        }

       
    /// <summary>
    /// 編集
    /// </summary>
    /// <param name="id"></param>
        public async void OnEdit(long id)
        {
            NavManager.NavigateTo(PageList.HAIKUEDIT + "/" + id.ToString());
        }

        #endregion

        #region メソッド
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void Search()
        {
            Haikus.Clear();
            var records = FrontAPI.GetHaikus(this.KeyWord);
            this.Haikus.AddRange(records);
        }

        /// <summary>
        /// 削除
        /// </summary>
        /// <param name="id">管理番号</param>
        private void Delete(long id)
        {
            FrontAPI.DeleteHaiku(id);
        }
        #endregion

    }
}
