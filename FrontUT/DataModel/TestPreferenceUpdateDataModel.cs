using Interfaces.DataModels;

namespace FrontUT.DataModel
{
    /// <summary>
    ///  お気に入り更新用
    /// </summary>
    public class TestPreferenceUpdateDataModel : IPreferenceUpdateDataModel
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
        public string Author { get; set; }

        /// <summary>
        ///  出典
        /// </summary>
        public string Book { get; set; }

        /// <summary>
        ///  時代
        /// </summary>
        public string Era { get; set; }

        /// <summary>
        ///  見出し
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        ///  備考
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        ///  更新日時
        /// </summary>
        public string UpdateDate { get; set; }
        #endregion

        #region コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public TestPreferenceUpdateDataModel()
        {
        }
        #endregion
    }
}