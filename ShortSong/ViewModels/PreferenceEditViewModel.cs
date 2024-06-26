﻿using FLayer;
using Interfaces.DataModels;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using ShortSong.Data;

namespace ShortSong.ViewModels
{
    /// <summary>
    /// お気に入り
    /// </summary>
    public class PreferenceEditViewModel:ComponentBase
    {

        #region プロパティ

        /// <summary>
        /// ID
        /// </summary>
        [Parameter]
        public string Id { get; set; }

        /// <summary>
        /// 歌
        /// </summary>
        [Parameter]
        public string Uta { get; set; } = null!;

        /// <summary>
        /// 作者
        /// </summary>
        [Parameter]
        public string Author { get; set; } = null!;

        /// <summary>
        /// 短歌
        /// </summary>
        [Parameter]
        public string? Book { get; set; }

        /// <summary>
        /// 時代
        /// </summary>
        [Parameter]
        public string? Era { get; set; }

        /// <summary>
        /// 見出し
        /// </summary>
        [Parameter]
        public string? Index { get; set; }

        /// <summary>
        /// 備考
        /// </summary>
        [Parameter]
        public string? Memo { get; set; }

        #endregion

        #region サービス
        /// <summary>
        /// ダイアログ
        /// </summary>
        [Inject]
        public IMatDialogService MatDialogService { get; set; }

        /// <summary>
        /// ナビゲーション
        /// </summary>
        [Inject]
        protected NavigationManager NavManager { get; set; }

       
        #endregion

        #region イベント

        /// <summary>
        /// 初期化イベント
        /// </summary>
        /// <returns></returns>
        protected override Task OnInitializedAsync()
        {
            long lid = Convert.ToInt64(Id);

          
            var target = FrontAPI.GetPreference(lid);
            this.CopyContent(target);

            return base.OnInitializedAsync();

        }

      
        /// <summary>
        /// お気に入り編集イベント
        /// </summary>
        public void OnEditPreferenceAsync()
        {
            var model = this.CreateModel();
        

            if (FrontAPI.UpdatePregerence(model))
            {
                MatDialogService.AlertAsync("お気に入りを更新しました。");
            }
            else
            {
                MatDialogService.AlertAsync("お気に入りの更新失敗しました。");
            }
        }

        #endregion

        #region メソッド

        /// <summary>
        /// 内容コピー
        /// </summary>
        /// <param name="target"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void CopyContent(IPreferenceUpdateDataModel target)
        {
            this.Uta = target.Uta;
            this.Author = target.Author;
            this.Book = target.Book;
            this.Era = target.Era;
            this.Index = target.Index;
            this.Memo = target.Memo;
        }

        /// <summary>
        /// お気に入り更新
        /// </summary>
        /// <returns></returns>
        private ClientPreferenceUpdateDataModel CreateModel()
        {
            var model = new ClientPreferenceUpdateDataModel();
            model.Id= Convert.ToInt32(this.Id);
            model.Uta= this.Uta;
            model.Author = this.Author;
            model.Book = this.Book;
            model.Era = this.Era;
            model.Index = this.Index;
            model.Memo = this.Memo;
            model.UpdateDate = DateTime.Now.ToString();
           
            return model;
        }

        #endregion
    }
}
