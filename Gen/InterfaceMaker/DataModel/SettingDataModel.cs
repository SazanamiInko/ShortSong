namespace InterfaceMaker.DataModel
{
    /// <summary>
    /// 設定データモデル
    /// </summary>
    public class SettingDataModel
    {
        #region プロパティ
        /// <summary>
        /// 作業フォルダ
        /// </summary>
        public string WorkFolder{get;set;}

        /// <summary>
        /// 出力フォルダ
        /// </summary>
        public string OutputFolder { get; set; }

        /// <summary>
        /// T4情報
        /// </summary>
        public List<InheritedT4DataModel> T4Infos { get; set; }
        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SettingDataModel()
        {
            this.T4Infos=new List<InheritedT4DataModel>();
        }

        #endregion

    }
}
