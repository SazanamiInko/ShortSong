namespace BLayer.DataModel
{
    /// <summary>
    /// 俳句データモデル
    /// </summary>
    public class HaikuModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 前書き
        /// </summary>
        public string Front { get; set; }

        /// <summary>
        /// 俳句
        /// </summary>
        public string Haiku { get; set; } = null!;

        /// <summary>
        /// かな
        /// </summary>
        public string Kana { get; set; } = null!;

        /// <summary>
        /// 英語
        /// </summary>
        public string? English { get; set; }

        /// <summary>
        /// 備考
        /// </summary>
        public string? Memo { get; set; }

        /// <summary>
        /// 季節
        /// </summary>
        public long Seazon { get; set; }

        /// <summary>
        /// 季語
        /// </summary>
        public string SeazonWord { get; set; }


        /// <summary>
        /// 見出し
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        /// 作成日時
        /// </summary>
        public string CreateDateTime { get; set; } = null!;
        /// <summary>
        /// 更新日時
        /// </summary>
        public string UpdateDateTime { get; set; } = null!;
        /// <summary>
        /// 更新回数
        /// </summary>
        public long UpdateCount { get; set; } 

        /// <summary>
        /// 削除フラグ
        /// </summary>
        public long Delete { get; set; }

    }
}
