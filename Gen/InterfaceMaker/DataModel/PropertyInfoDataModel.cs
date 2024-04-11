namespace InterfaceMaker.DataModel
{
    /// <summary>
    /// プロパティ情報
    /// </summary>
    public class PropertyInfoDataModel
    {
        /// <summary>
        /// プロパティ名
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// コメント
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// リストフラグ
        /// </summary>
        public bool IsList { get; set; }

        /// <summary>
        /// Readフラグ
        /// </summary>
        public bool IsRead { get; set; }
    }
}
