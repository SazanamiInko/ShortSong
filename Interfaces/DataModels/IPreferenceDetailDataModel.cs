
namespace Interfaces.DataModels
{

    /// <summary>
    ///  お気に入り詳細
    /// </summary>
    public interface IPreferenceDetailDataModel
    {

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

    }
}