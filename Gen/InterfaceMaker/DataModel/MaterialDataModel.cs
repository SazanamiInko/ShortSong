namespace InterfaceMaker.DataModel
{
    /// <summary>
    /// 材料モデル
    /// </summary>
    public class MaterialDataModel
    {
        #region プロパティ

        /// <summary>
        /// クラス名
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// コメント
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// プロパティリスト
        /// </summary>
        public List<PropertyInfo> Propertys{ get; }

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MaterialDataModel() 
        { 
            this.Propertys = new List<PropertyInfo>();
        }

        #endregion


    }
}
