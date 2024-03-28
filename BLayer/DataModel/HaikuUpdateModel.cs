namespace BLayer.DataModel
{
    /// <summary>
    /// 俳句更新モデル
    /// </summary>
    public class HaikuUpdateModel
    {
        /// <summary>
        /// 管理番号
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 前書き
        /// </summary>
        public string Front { get; set; } = null!;

        /// <summary>
        /// 俳句
        /// </summary>
        public string Haiku { get; set; } = null!;

        /// <summary>
        /// カナ
        /// </summary>
        public string Kana { get; set; } = null!;

        /// <summary>
        /// 英語
        /// </summary>
        public string? English { get; set; }

        /// <summary>
        /// 季語
        /// </summary>
        public string? SeazonWord { get; set; }

        /// <summary>
        /// 季節
        /// </summary>
        public long Seazon { get; set; }

        /// <summary>
        /// 見出し
        /// </summary>
        public string? Index { get; set; }

        /// <summary>
        /// 備考
        /// </summary>
        public string? Memo { get; set; }

        /// <summary>
        /// 更新日時
        /// </summary>
        public string UpdateDateTime { get; set; } = null!;

        /// <summary>
        /// 更新回数
        /// </summary>
        public long UpdateCount { get; set; }

        /// <summary>
        /// コメント
        /// </summary>
        public string? Comment { get; set; }
    }
}
