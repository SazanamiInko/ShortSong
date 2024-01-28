namespace BLayer.DataModel
{
    /// <summary>
    /// 短歌モデル
    /// </summary>
    public class ShortSongModel
    {
        /// <summary>
        /// 管理番号
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 前書き
        /// </summary>
        public string Front { get; set; }

        /// <summary>
        /// 短歌
        /// </summary>
        public string Uta { get; set; } = null!;

        /// <summary>
        /// カナ
        /// </summary>
        public string Kana { get; set; } = null!;

        /// <summary>
        /// 英語
        /// </summary>
        public string? English { get; set; }

        /// <summary>
        /// 見出し
        /// </summary>
        public string? Index { get; set; }

        /// <summary>
        /// 備考
        /// </summary>
        public string? Memo { get; set; }

        /// <summary>
        /// 季節
        /// </summary>
        public long Seazon { get; set; }

        /// <summary>
        /// 作成日時
        /// </summary>
        public string CreateDate { get; set; } = null!;

        /// <summary>
        /// 削除フラグ
        /// </summary>
        public long Delete { get; set; }

        /// <summary>
        /// 本歌
        /// </summary>
        public string? RefUta { get; set; }
    }
}
