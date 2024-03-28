namespace BLayer.DataModel
{
    /// <summary>
    /// 俳句検索結果
    /// </summary>
    public class HaikuSimple
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 俳句
        /// </summary>
        public string? Haiku { get; set; }

        /// <summary>
        /// 見出し
        /// </summary>
        public string? Index { get; set; }
    }
}
