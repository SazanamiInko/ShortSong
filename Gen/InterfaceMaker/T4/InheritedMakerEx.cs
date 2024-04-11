using InterfaceMaker.DataModel;

namespace InterfaceMaker.T4
{
    /// <summary>
    /// 派生データモデル
    /// </summary>
    public partial class InheritedMaker
    {
        #region プロパティ

        /// <summary>
        /// 材料
        /// </summary>
        public MaterialDataModel MaterialDataModel { get; set; }

        /// <summary>
        /// 派生情報モデル
        /// </summary>
        public InheritedT4DataModel InheritedT4DataModel { get; set; }
        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public InheritedMaker() 
        { 
            this.MaterialDataModel = new MaterialDataModel();
        }

        #endregion

        #region メソッド

        /// <summary>
        /// クラス名
        /// </summary>
        /// <returns></returns>
        public string GetClassName()
        {
            return $"{InheritedT4DataModel.Name}{MaterialDataModel.ClassName}DataModel";
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
