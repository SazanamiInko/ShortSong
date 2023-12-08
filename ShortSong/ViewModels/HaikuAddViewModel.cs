using BLayer.DataModel;
using BLayer.Logics;
using DLayer.Models;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace ShortSong.ViewModels
{
    public class HaikuAddViewModel : ComponentBase
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
        public string Index{ get; set; }

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
        public HaikuAddViewModel()
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
            SeazonLogic seazonLogic = new SeazonLogic();
            seazonLogic.Context = this.Context;

            this.Seazons.AddRange(seazonLogic.GetSeazons());

            return base.OnInitializedAsync();
        }

        /// <summary>
        /// 短歌登録
        /// </summary>
        public async Task OnAddHaikuAsync()
        {
            AddUnEnable = true;
            var model = CreateDataModel();

            HaikuLogic logic = new HaikuLogic();
            logic.Context = this.Context;

            if (logic.AddHaiku(model))
            {
                await MatDialogService.AlertAsync("俳句を登録しました。");

            }
            else
            {
                await MatDialogService.AlertAsync("俳句登録に失敗しました。");
                return;
            }
            this.Clear();
            AddUnEnable = false;
        }


        #endregion


        /// <summary>
        /// 内容消去
        /// </summary>
        private void Clear()
        {
            HaikuLogic logic = new HaikuLogic();
            logic.Context = this.Context;

            this.Id = logic.PublishedID();
            this.Haiku = string.Empty;
            this.Kana = string.Empty;
            this.English = string.Empty;
            this.Memo = string.Empty;
           
            this.Front = string.Empty;
           this.Index=string.Empty;
            this.SeazonWord = string.Empty;

        }

        /// <summary>
        /// データモデル作成
        /// </summary>
        /// <returns>データモデル</returns>
        private HaikuModel CreateDataModel()
        {
            HaikuLogic logic = new HaikuLogic();
            logic.Context = this.Context;

            HaikuModel model = new HaikuModel();
            model.Id = logic.PublishedID();
            model.Haiku = this.Haiku;
            model.Kana = this.Kana;
            model.English = this.English;
            model.Memo = this.Memo;
           
            model.Seazon = this.Seazon;
            model.Front = this.Front;
           
            model.CreateDate = DateTime.Now.ToString();
            model.UpdateDate = DateTime.Now.ToString();
            model.UpdateCount = 0;
            return model;
        }
    }
}
