using Interfaces.DataModels;

namespace BLayer.DataModel
{
    /// <summary>
    ///  お気に入り一括
    /// </summary>
    public class ServerPreferenceBatchDataModel : IPreferenceBatchDataModel
    {
        #region プロパティ

        /// <summary>
        ///  管理番号
        /// </summary>
        public long Id { get; set; }

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
        ///  詳細リスト
        /// </summary>
        public List<IPreferenceDetailDataModel> Items { get; }

        /// <summary>
        ///  登録日時
        /// </summary>
        public string CreateDate { get; set; }
        #endregion

        #region コンストラクタ
        /// <summary>
        ///  コンストラクタ
        /// </summary>
        public ServerPreferenceBatchDataModel()
        {
            this.Items = new List<IPreferenceDetailDataModel>();
        }
        #endregion
    }
}