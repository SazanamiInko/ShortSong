using GenBLayer.DataMpdels;

namespace GenBLayer
{
    /// <summary>
    /// テストデータ作成
    /// </summary>
    public class TestDataGen
    {
        /// <summary>
        /// テストデータクラス作成
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public TestDataGenDataModel CreateTestGenDataModel(string path)
        {
            TestDataGenDataModel dm = new TestDataGenDataModel();

            //テストデータオブジェクトがファイル名

            FileInfo info= new FileInfo(path);

            dm.Target = info.Name;

            return dm;
        }
    }
}
