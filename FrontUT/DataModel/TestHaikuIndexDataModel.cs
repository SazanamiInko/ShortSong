using Interfaces.DataModels;

namespace FrontUT.DataModel
{
    /// <summary>
    ///  俳句一覧用
    /// </summary>
    public class TestHaikuIndexDataModel : IHaikuIndexDataModel
    {
        #region プロパティ

        /// <summary>
        ///  管理番号
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///  俳句
        /// </summary>
        public string Haiku { get; set; }

        /// <summary>
        ///  見出し
        /// </summary>
        public string Index { get; set; }
        #endregion

        #region コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public TestHaikuIndexDataModel()
        {
        }
        #endregion
    }
}