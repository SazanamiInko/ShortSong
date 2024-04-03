using BLayer.DataModel;
using MatBlazor;
using Microsoft.AspNetCore.Components;

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
        public HaikuEditViewModel()
        {
            AddUnEnable = false;
            this.Seazons = new List<SeazonModel>();
        }

        #endregion
    }
}
