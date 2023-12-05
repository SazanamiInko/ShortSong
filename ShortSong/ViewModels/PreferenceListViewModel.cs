using BLayer.DataModel;
using BLayer.Logics;
using DLayer.Models;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using ShortSong.Common;
using System.ComponentModel;

namespace ShortSong.ViewModels
{
    public class PreferenceListViewModel:ComponentBase
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
        public List<PreferenceSimpleModel> Preferences { get; set; }

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

        /// <summary>
        /// データコンテキスト
        /// </summary>
        [Inject]
        public UtaContext Context { get; set; }

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PreferenceListViewModel()
        {
            this.Preferences = new List<PreferenceSimpleModel>();
        }

        #endregion

        #region イベント
        /// <summary>
        /// 検索
        /// </summary>
        public async void OnSearch()
        {

            Search();

            if (Preferences.Count == 0)
            {
                await MatDialogService.AlertAsync("お気に入りがありませんでした。");
            }
        }


        /// <summary>
        /// 削除イベント
        /// </summary>
        /// <param name="id"></param>
        public async void OnDelete(long id)
        {
            var result = await MatDialogService.ConfirmAsync("お気に入りを削除していいですか?");

            if (result)
            {
               this.Delete(id);
                this.Search();
            }
            this.StateHasChanged();
        }

        /// <summary>
        /// 編集画面へ
        /// </summary>
        /// <param name="id"></param>
        public void OnEdit(long id)
        {
            NavManager.NavigateTo(PageList.PREFERENCEEDIT+"/" + id.ToString());
        }

        #endregion

        #region メソッド

        /// <summary>
        /// 検索
        /// </summary>
        public void Search()
        {
            Preferences.Clear();

            PreferenceLogic logic = new PreferenceLogic();
            logic.context = Context;
           var records= logic.GetPreferences(this.KeyWord);
            this.Preferences.AddRange(records);
        }

        /// <summary>
        /// 削除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id)
        {
            PreferenceLogic logic = new PreferenceLogic();
            logic.context = Context;
            logic.DeletePrefernce(id);
        }

        #endregion
    }
}
