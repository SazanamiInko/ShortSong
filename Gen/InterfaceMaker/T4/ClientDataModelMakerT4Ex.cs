using InterfaceMaker.DataModel;

namespace InterfaceMaker.T4
{
    /// <summary>
    /// インタフェース自動生成拡張クラス
    /// </summary>
    public partial class ClientDataModelMakerT4
    {
        #region プロパティ

        /// <summary>
        /// 材料
        /// </summary>
        public MaterialDataModel MaterialDataModel{get; set;}
        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ClientDataModelMakerT4()
        {
            MaterialDataModel = new MaterialDataModel();
        }

        #endregion

        #region メソッド

        /// <summary>
        /// クラス名
        /// </summary>
        /// <returns></returns>
        public string GetClassName()
        {
            return $"Client{MaterialDataModel.ClassName}DataModel";              
        }


        /// <summary>
        /// ファイル名取得
        /// </summary>
        /// <returns></returns>
        public string GetFileName()
        {
            return $"{this.GetClassName()}.cs";
        }
        #endregion
    }
}
