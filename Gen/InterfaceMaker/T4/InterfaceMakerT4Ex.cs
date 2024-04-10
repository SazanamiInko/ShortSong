using InterfaceMaker.DataModel;

namespace InterfaceMaker.T4
{
    /// <summary>
    /// インタフェース作成拡張
    /// </summary>
    public partial class InterfaceMakerT4
    {
        #region プロパティ

        /// <summary>
        /// 原料
        /// </summary>
        public MaterialDataModel MaterialDataModel{get; set;}

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public InterfaceMakerT4()
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
            return $"I{MaterialDataModel.ClassName}DataModel";
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
