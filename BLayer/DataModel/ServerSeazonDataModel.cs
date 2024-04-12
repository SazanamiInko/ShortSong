using Interfaces.DataModels;

namespace BLayer.DataModel
{
    /// <summary>
    ///  季節
    /// </summary>
    public class ServerSeazonDataModel : ISeazonDataModel
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
        public ServerSeazonDataModel()
        {
        }
        #endregion
    }
}