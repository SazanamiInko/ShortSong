using Interfaces.DataModels;

namespace FrontUT.DataModel
{
    /// <summary>
    ///  短歌一覧用
    /// </summary>
    public class TestShortSongIndexDataModel : IShortSongIndexDataModel
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
        ///  見出し
        /// </summary>
        public string Index { get; set; }
        #endregion

        #region コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public TestShortSongIndexDataModel()
        {
        }
        #endregion
    }
}