using BLayer.DataModel;
using BLayer.Logics;
using DLayer.Models;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace ShortSong.ViewModels
{
    /// <summary>
    /// 短歌編集ビューモデル
    /// </summary>
    public class ShortSongEditViewModel : ComponentBase
    {
        #region プロパティ

        /// <summary>
        /// ID
        /// </summary>
        [Parameter]
        public string Id { get; set; }

        /// <summary>
        /// 短歌
        /// </summary>
        [Parameter]
        public string Shortsong1 { get; set; }

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
        public long Seazon { get; set; }

        /// <summary>
        /// コメント
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 更新回数
        /// </summary>
        public long UpdateCount { get; set; }

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

        /// <summary>
        /// ナビゲーション
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
        public ShortSongEditViewModel()
        {

            this.Seazons = new List<SeazonModel>();
        }

        #endregion

        #region イベント

        /// <summary>
        /// 初期化イベント
        /// </summary>
        /// <returns></returns>
        protected override Task OnInitializedAsync()
        {

            SeazonLogic seazonLogic = new SeazonLogic();
            seazonLogic.Context = this.Context;

            
            this.Seazons.AddRange(seazonLogic.GetSeazons());


            long lid = Convert.ToInt64(Id);
            ShortSongLogic logic = new ShortSongLogic();
            logic.Context = this.Context;

            var target = logic.GetShortSong(lid);
            this.CopyContent(target);

            return base.OnInitializedAsync();

        }

        public async void OnEditShortSongAsync()
        {

            var model = this.CreateModel();
            ShortSongLogic logic = new ShortSongLogic();
            logic.Context = this.Context;

            if (logic.UpdateShortSong(model))
            {

                MatDialogService.AlertAsync("短歌を更新しました。");
            }
            else
            {
                MatDialogService.AlertAsync("短歌の更新に失敗しました。");
            }
        }

        #endregion

        #region メソッド

        /// <summary>
        /// モデル転写
        /// </summary>
        /// <param name="model">転写するモデル</param>
        private void CopyContent(ShortSongUpdateModel model)
        {
            this.Id = model.Id.ToString();
            this.Shortsong1 = model.Uta;
            this.Kana = model.Kana;
            this.English = model.English;
            this.Index = model.Index;
            this.Seazon = model.Seazon;
            this.Memo = model.Memo;
            this.RefUta = model.RefUta;
            this.Front = model.Front;
            this.UpdateCount = model.UpdateCount;
        }

        /// <summary>
        /// 短歌更新
        /// </summary>
        /// <returns></returns>
        private ShortSongUpdateModel CreateModel()
        {
            var model = new ShortSongUpdateModel();

            model.Id = Convert.ToInt64(Id);
            model.Uta = this.Shortsong1;
            model.Kana = this.Kana;
            model.English = this.English;
            model.Index = this.Index;
            model.Seazon = this.Seazon;
            model.Memo = this.Memo;
            model.RefUta = this.RefUta;
            model.Front = this.Front;
            model.UpdateDate = DateTime.Now.ToString();
            model.UpdateCount = this.UpdateCount + 1;
            return model;
        }

        #endregion
    }
}
