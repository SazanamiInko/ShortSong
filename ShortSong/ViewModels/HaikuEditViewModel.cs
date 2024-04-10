using BLayer.DataModel;
using FLayer;
using Interfaces.DataModels;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using ShortSong.Data;

namespace ShortSong.ViewModels
{
    /// <summary>
    /// 俳句編集ビューモデル
    /// </summary>
    public class HaikuEditViewModel: ComponentBase
    {
        #region プロパティ

        /// <summary>
        /// ID
        /// </summary>
        [Parameter]
        public string Id { get; set; }

        /// <summary>
        /// 前書き
        /// </summary>
        [Parameter]
        public string Front { get; set; }


        /// <summary>
        ///　俳句
        /// </summary>
        [Parameter]
        public string Haiku { get; set; }

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
        /// 季語
        /// </summary>
        [Parameter]
        public string SeazonWord { get; set; }


        /// <summary>
        /// 備考
        /// </summary>
        [Parameter]
        public string Memo { get; set; }


        /// <summary>
        /// 見出し
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
        public List<ISeazonDataModel> Seazons { get; }

        /// <summary>
        /// コメント
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 更新回数
        /// </summary>
        public long UpdateCount { get; set; }

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
        public HaikuEditViewModel()
        {
            AddUnEnable = false;
            this.Seazons = new List<ISeazonDataModel>();
        }

        #endregion

        #region イベント

        /// <summary>
        /// 初期化イベント
        /// </summary>
        /// <returns></returns>
        protected override Task OnInitializedAsync()
        {
            this.Seazons.AddRange(FrontAPI.GetSeazons());
            long lid = Convert.ToInt64(Id);
           

            var target = FrontAPI.GetHaiku(lid);
            this.CopyContent(target);

            return base.OnInitializedAsync();

        }

        /// <summary>
        /// 俳句編集
        /// </summary>
        protected void OnEditHaikuAsync()
        {
            var model = this.CreateModel();


            if (FrontAPI.UpdateHaiku(model))
            {

                _ = MatDialogService.AlertAsync("俳句を更新しました。");
            }
            else
            {
                _ = MatDialogService.AlertAsync("俳句の更新に失敗しました。");
            }
        }


        #endregion

        #region メソッド

        /// <summary>
        /// モデルコピー
        /// </summary>
        /// <param name="model"></param>
        private void CopyContent(IHaikuDataModel model)
        {
            this.Id = model.Id.ToString();
            this.Haiku = model.Haiku;
            this.Kana = model.Kana;
            this.English = model.English;
            this.Index = model.Index;
            this.Seazon = model.Seazon;
            this.SeazonWord = model.SeazonWord;
            this.Memo = model.Memo;
            this.Front = model.Front;
            this.UpdateCount = model.UpdateCount;
        }

        /// <summary>
        /// モデル作成
        /// </summary>
        /// <returns></returns>
        private ClientHaikuUpdateDataModel CreateModel()
        {
            ClientHaikuUpdateDataModel model = new ClientHaikuUpdateDataModel();

            model.Id = Convert.ToInt64(this.Id);
            model.Haiku = this.Haiku;
            model.Kana = this.Kana;
            model.English = this.English;
            model.Index = this.Index;
            model.Seazon = this.Seazon;
            model.SeazonWord = this.SeazonWord;
            model.Memo = this.Memo;
            model.Front = this.Front;

            return model;
        }
        #endregion


    }
}
