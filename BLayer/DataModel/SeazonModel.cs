namespace BLayer.DataModel
{
    /// <summary>
    /// 季節モデル
    /// </summary>
    public class SeazonModel
    {
        /// <summary>
        /// コード
        /// </summary>
        public long Code { get; set; }

        /// <summary>
        /// 値
        /// </summary>
        public string Value { get; set; } = null!;
    }
}
