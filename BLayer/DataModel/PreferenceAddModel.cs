namespace BLayer.DataModel
{
    /// <summary>
    /// お気に入りモデル
    /// </summary>
    public class PreferenceAddModel
    {
        /// <summary>
        /// 短歌
        /// </summary>
        public string Uta { get; set; } = null!;
        
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; } = null!;

        /// <summary>
        /// 出典
        /// </summary>
        public string? Book { get; set; }

        /// <summary>
        /// 時代
        /// </summary>
        public string? Era { get; set; }

        /// <summary>
        /// 見出し
        /// </summary>
        public string? Index { get; set; }

        /// <summary>
        /// 備考
        /// </summary>
        public string? Memo { get; set; }

        public string? CreateDate { get; set; }
    }
}
