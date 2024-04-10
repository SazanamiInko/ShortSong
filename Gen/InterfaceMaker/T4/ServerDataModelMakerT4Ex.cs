using InterfaceMaker.DataModel;

namespace InterfaceMaker.T4
{
    /// <summary>
    /// サーバーソース自動作成拡張
    /// </summary>
    public partial class ServerDataModelMakerT4
    {
        #region プロパティ

        /// <summary>
        /// プロパティ
        /// </summary>
        public MaterialDataModel MaterialDataModel{get; set;}

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ServerDataModelMakerT4()
        {
            this.MaterialDataModel = new MaterialDataModel();
        }

        #endregion

        #region メソッド

        /// <summary>
        /// クラス名取得
        /// </summary>
        /// <returns></returns>
        public string GetClassName()
        {
            return $"Server{MaterialDataModel.ClassName}DataModel";
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
