using GenBLayer.DataMpdels;

namespace GenFront
{
    partial class DataGenEngine
    {
        /// <summary>
        /// テストデータモデル
        /// </summary>
        private TestDataGenDataModel model;

        /// <summary>
        /// 隠すコンストラクタ
        /// </summary>
        private DataGenEngine() { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="model">モデル</param>
        public DataGenEngine(TestDataGenDataModel model)
        {
            this.model = model;
        }
    }
}
