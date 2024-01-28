namespace BLayer.DataModel
{
    /// <summary>
    /// お気に入り一覧モデル
    /// </summary>
    public class PreferenceSimpleModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// 歌
        /// </summary>
        public string Uta { get; set; } = null!;

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; } = null!;
    }
}
