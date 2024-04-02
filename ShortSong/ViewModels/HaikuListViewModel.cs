using BLayer.DataModel;
using FLayer;
using MatBlazor;
using Microsoft.AspNetCore.Components;

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
        public List<HaikuSimple> Haikus { get; set; }

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
            this.Haikus = new List<HaikuSimple>();
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

        public async void OnDelete(long id)
        {

        }

        public async void OnEdit(long id)
        {

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
        #endregion

    }
}
