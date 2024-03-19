
using BLayer.DataModel;
using BLayer.Logics;
using DLayer.Models;
using DLayer.Services;
using FLayer;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace ShortSong.ViewModels
{
    /// <summary>
    /// 短歌登録ビューモデル
    /// </summary>
    public class ShortSongAddViewModel:ComponentBase
    {
        #region プロパティ

        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 前書き
        /// </summary>
        [Parameter]
        public string Front { get; set; }

        /// <summary>
        /// 本歌
        /// </summary>
        [Parameter]
        public string RefUta { get; set; }

        /// <summary>
        /// 短歌
        /// </summary>
        [Parameter]
        public string Shortsong1 { get; set; }

        /// <summary>
        /// かな
        /// </summary>
        [Parameter]
        public string Kana { get; set; }

        /// <summary>
        /// 英語
        /// </summary>
        [Parameter]
        public string English { get; set; }

        /// <summary>
        /// 作成日
        /// </summary>
        [Parameter]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 備考
        /// </summary>
        [Parameter]
        public string Memo { get; set; }

        /// <summary>
        /// 目次
        /// </summary>
        [Parameter]
        public string Index { get; set; }

        /// <summary>
        /// 季節
        /// </summary>
        [Parameter]
        public long Seazon { get; set; }

        /// <summary>
        /// ボタン活性
        /// </summary>
        [Parameter]
        public bool AddUnEnable { get; set; }

        /// <summary>
        /// 季節マスタ
        /// </summary>
        public List<SeazonModel> Seazons { get; }

        #endregion

        #region サービス

        /// <summary>
        /// ダイアログ
        /// </summary>
        [Inject]
        public IMatDialogService MatDialogService { get; set; }

      
        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ShortSongAddViewModel()
        {
            AddUnEnable = false;
            this.Seazons = new List<SeazonModel>();
        }

        #endregion

        #region イベント

        /// <summary>
        /// 初期化
        /// </summary>
        /// <returns></returns>
        protected override Task OnInitializedAsync()
        {      
            this.Seazons.AddRange(FrontAPI.GetSeazons());
            return base.OnInitializedAsync();
        }

        /// <summary>
        /// 短歌登録
        /// </summary>
        public async Task OnAddShortSongAsync()
        {
            AddUnEnable = true;
            var model = CreateDataModel();

            if (FrontAPI.AddShortSong(model))
            {
                await MatDialogService.AlertAsync("短歌を登録しました。");

            }
            else
            {
                await MatDialogService.AlertAsync("短歌登録に失敗しました。");
                return;
            }
            this.Clear();
            AddUnEnable = false;
        }

        #endregion

        #region メソッド

        /// <summary>
        /// 内容消去
        /// </summary>
        private void Clear()
        {
            
            this.Id = FrontAPI.PublishIDShortSong();
            this.Shortsong1 = string.Empty;
            this.Kana = string.Empty;
            this.English = string.Empty;
            this.Memo = string.Empty;
            this.Index = string.Empty;
            this.Front= string.Empty;
            this.RefUta= string.Empty;

        }

        /// <summary>
        /// データモデル作成
        /// </summary>
        /// <returns>データモデル</returns>
        private ShortSongModel CreateDataModel()
        {
          
            ShortSongModel model = new ShortSongModel();
            model.Id = FrontAPI.PublishIDShortSong();
            model.Uta = this.Shortsong1;
            model.Kana = this.Kana;
            model.English = this.English;
            model.Memo = this.Memo;
            model.Index = this.Index;
            model.Seazon = this.Seazon;
            model.Front = this.Front;
            model.RefUta = this.RefUta;
            model.CreateDate = DateTime.Now.ToString();
            return model;
        }

        #endregion

    }
}
