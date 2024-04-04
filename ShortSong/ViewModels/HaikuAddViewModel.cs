using BLayer.DataModel;
using FLayer;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace ShortSong.ViewModels
{
    public class HaikuAddViewModel : ComponentBase
    {

        #region プロパティ

        /// <summary>
        /// ID
        /// </summary>
        [Parameter]
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
           

            this.Seazons.AddRange(FrontAPI.GetSeazons());

            return base.OnInitializedAsync();
        }

        /// <summary>
        /// 短歌登録
        /// </summary>
        public async Task OnAddHaikuAsync()
        {
            AddUnEnable = true;
            var model = CreateDataModel();

            if (FrontAPI.AddHaiku(model))
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

            this.Id = FrontAPI.PublishedHaikuId();
            this.Haiku = string.Empty;
            this.Kana = string.Empty;
            this.English = string.Empty;
            this.Memo = string.Empty;

            this.Front = string.Empty;
            this.Index = string.Empty;
            this.SeazonWord = string.Empty;
            this.Seazon = 0;
        }

        /// <summary>
        /// データモデル作成
        /// </summary>
        /// <returns>データモデル</returns>
        private HaikuModel CreateDataModel()
        {
          ;

            //俳句モデルの作成
            HaikuModel model = new HaikuModel();
            //ID番号の発行
            model.Id = FrontAPI.PublishedHaikuId();

            #region データ作成
            //俳句
            model.Haiku = this.Haiku;
            //かな
            model.Kana = this.Kana;
            //英語
            model.English = this.English;
            //備考
            model.Memo = this.Memo;
            //季節
            model.Seazon = this.Seazon;
            //前書き
            model.Front = this.Front;
            //季語
            model.SeazonWord = this.SeazonWord;
            //見出し
            model.Index = this.Index;

            //作成日時
            model.CreateDateTime = DateTime.Now.ToString();
            //更新日時
            model.UpdateDateTime = DateTime.Now.ToString();
            //更新回数
            model.UpdateCount = 0;
            #endregion

            return model;
        }
    }
}
