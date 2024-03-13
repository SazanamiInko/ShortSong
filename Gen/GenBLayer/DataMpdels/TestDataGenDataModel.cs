namespace GenBLayer.DataMpdels
{
    /// <summary>
    /// テストデータ作成データモデル
    /// </summary>
    public class TestDataGenDataModel
    {
        #region プロパティ
        /// <summary>
        /// 対象名
        /// </summary>
        public string Target { get; set; } = string.Empty;

        /// <summary>
        /// クラス名
        /// </summary>
        public string ClassName 
        { get
            
            { 
                return Target + "DataGen"; 
            } 
        }

        /// <summary>
        /// メソッド
        /// </summary>
        public List<TestMethodDataGenModel> TestGenMethods { get; }
        #endregion

        #region コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public TestDataGenDataModel()
        {
            TestGenMethods = new List<TestMethodDataGenModel>();
        }
        #endregion
    }
}
