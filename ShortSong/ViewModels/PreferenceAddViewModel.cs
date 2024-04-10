using BLayer.DataModel;
using FLayer;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using ShortSong.Data;

namespace ShortSong.ViewModels
{
    /// <summary>
    /// お気に入り登録画面ビューモデル
    /// </summary>
    public class PreferenceAddViewModel:ComponentBase
    {
        #region 定数

        #endregion

        #region プロパティ
        /// <summary>
        /// 歌
        /// </summary>
        public string Uta { get; set; } = null!;

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; } = null!;

        /// <summary>
        /// 短歌
        /// </summary>
        public string? Book { get; set; }

    /// <summary>
    /// 時代
    /// </summary>
        public string? Era { get; set; }

        /// <summary>
        /// 見出し
        /// </summary>
        public string? Index { get; set; }

        /// <summary>
        /// 備考
        /// </summary>
        public string? Memo { get; set; }

        #endregion

        #region サービス

        /// <summary>
        /// ダイアログ
        /// </summary>
        [Inject]
        public IMatDialogService MatDialogService { get; set; }

       
        #endregion


        #region イベント

        /// <summary>
        /// お気に入り登録
        /// </summary>
        /// <returns></returns>
        public async Task OnAddPreferenceAsync()
        {
            var model = this.CreateModel();


            if (FrontAPI.AddPreference(model))
            {
                await MatDialogService.AlertAsync("お気に入りを登録しました。");

            }
            else
            {
                await MatDialogService.AlertAsync("お気に入り登録に失敗しました。");
                return;
            }
            this.Clear();

        }
        #endregion

        #region メソッド

        /// <summary>
        /// 画面の内容クリア
        /// </summary>
        public void Clear() 
        {
            this.Uta = string.Empty;
            this.Author=string.Empty;
            this.Book=string.Empty;
            this.Era = string.Empty;
            this.Index = string.Empty;
            this.Memo = string.Empty;
        }

        /// <summary>
        /// モデル情報をセット
        /// </summary>
        /// <returns></returns>
        public ClientPreferenceDataModel CreateModel()
        {
            ClientPreferenceDataModel model = new ClientPreferenceDataModel();

            model.Uta = this.Uta;
            model.Author = this.Author;
            model.Book = this.Book;
            model.Era = this.Era;
            model.Index = this.Index;
            model.Memo = this.Memo;
            model.CreateDate = DateTime.Now.ToString();

            return model;
        }
        #endregion
    }
}
