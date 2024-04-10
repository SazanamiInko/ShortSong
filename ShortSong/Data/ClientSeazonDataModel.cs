using Interfaces.DataModels;

namespace ShortSong.Data
{
    /// <summary>
    ///  季節
    /// </summary>
    public class ClientSeazonDataModel : ISeazonDataModel
    {
        #region プロパティ

        /// <summary>
        ///  管理番号
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///  値
        /// </summary>
        public string Value { get; set; }
        #endregion

        #region コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public ClientSeazonDataModel()
        {
        }
        #endregion
    }
}