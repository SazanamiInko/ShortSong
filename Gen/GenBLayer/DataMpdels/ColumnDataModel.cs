namespace GenBLayer.DataMpdels
{
    /// <summary>
    /// 列モデル
    /// </summary>
    public class ColumnDataModel
    {
        /// <summary>
        /// 列番号
        /// </summary>
        public int ColumnNo{get;set;}

        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName { get;set;}

        /// <summary>
        /// コメント
        /// </summary>
        public string Comment { get;set;}

        /// <summary>
        /// データタイプ
        /// </summary>
        public string Type { get; set; }
    }
}
