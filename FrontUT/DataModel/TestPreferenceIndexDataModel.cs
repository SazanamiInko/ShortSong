using Interfaces.DataModels;

namespace FrontUT.DataModel
{
    /// <summary>
    ///  お気に入り一覧用
    /// </summary>
    public class TestPreferenceIndexDataModel : IPreferenceIndexDataModel
    {
        #region プロパティ

        /// <summary>
        ///  管理番号
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///  短歌
        /// </summary>
        public string Uta { get; set; }

        /// <summary>
        ///  作者
        /// </summary>
        public string Auther { get; set; }
        #endregion

        #region コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public TestPreferenceIndexDataModel()
        {
        }
        #endregion
    }
}