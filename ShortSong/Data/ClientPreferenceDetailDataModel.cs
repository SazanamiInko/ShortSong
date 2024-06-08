using Interfaces.DataModels;

namespace ShortSong.Data
{
    /// <summary>
    ///  お気に入り詳細
    /// </summary>
    public class ClientPreferenceDetailDataModel : IPreferenceDetailDataModel
    {
        #region プロパティ

        /// <summary>
        ///  管理番号
        /// </summary>
        public bool Check { get; set; } = true;

        /// <summary>
        ///  短歌
        /// </summary>
        public string Uta { get; set; }

        /// <summary>
        ///  見出し
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        ///  備考
        /// </summary>
        public string Memo { get; set; }
        #endregion

        #region コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public ClientPreferenceDetailDataModel()
        {
        }
        #endregion
    }
}