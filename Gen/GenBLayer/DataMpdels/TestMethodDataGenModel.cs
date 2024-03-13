namespace GenBLayer.DataMpdels
{
    /// <summary>
    /// テストデータ作成メソッドモデル
    /// </summary>
    public class TestMethodDataGenModel
    {
        #region プロパティ

        /// <summary>
        /// メソッド名
        /// </summary>
        public string MethodName { get; set; } = string.Empty;

        /// <summary>
        /// 列情報
        /// </summary>
        public List<ColumnDataModel> Columnes { get; }

        /// <summary>
        /// テストデータ
        /// </summary>
        public List<ObjectLineModel> Data { get; }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TestMethodDataGenModel()
        {
            this.Columnes = new List<ColumnDataModel>();
            this.Data = new List<ObjectLineModel>();
        }
        #endregion
    }
}

