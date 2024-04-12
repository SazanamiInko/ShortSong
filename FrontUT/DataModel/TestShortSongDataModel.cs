using Interfaces.DataModels;

namespace FrontUT.DataModel
{
    /// <summary>
    ///  短歌
    /// </summary>
    public class TestShortSongDataModel : IShortSongDataModel
    {
        #region プロパティ

        /// <summary>
        ///  管理番号
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///  前書き
        /// </summary>
        public string Front { get; set; }

        /// <summary>
        ///  短歌
        /// </summary>
        public string Uta { get; set; }

        /// <summary>
        ///  かな
        /// </summary>
        public string Kana { get; set; }

        /// <summary>
        ///  英語
        /// </summary>
        public string English { get; set; }

        /// <summary>
        ///  見出し
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        ///  備考
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        ///  季節
        /// </summary>
        public long Seazon { get; set; }

        /// <summary>
        ///  登録日時
        /// </summary>
        public string CreateDate { get; set; }

        /// <summary>
        ///  削除フラグ
        /// </summary>
        public long Delete { get; set; }

        /// <summary>
        ///  本歌
        /// </summary>
        public string RefUta { get; set; }
        #endregion

        #region コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public TestShortSongDataModel()
        {
        }
        #endregion
    }
}