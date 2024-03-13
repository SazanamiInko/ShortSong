namespace GenBLayer.DataMpdels
{
    /// <summary>
    ///  テストオブジェクト
    /// </summary>
    public class ObjectLineModel
    {
        #region プロパティ
        /// <summary>
        /// オブジェクトNo
        /// </summary>
        public string ObjecctNo { get; set; } = string.Empty;

        /// <summary>
        /// パラメータ
        /// </summary>
        public List<ParameterDataerModel> Params { get; }
        #endregion

        #region MyRegion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ObjectLineModel()
        {
            this.Params = new List<ParameterDataerModel>();
        }
        #endregion
    }
}
