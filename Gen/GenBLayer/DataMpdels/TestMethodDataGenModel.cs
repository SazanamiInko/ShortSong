namespace GenBLayer.DataMpdels
{
    /// <summary>
    /// テストデータ作成メソッドモデル
    /// </summary>
    public class TestMethodDataGenModel
    {
        #region プロパティ

        /// <summary>
        /// メソッド名
        /// </summary>
        public string MethodName { get; set; } = string.Empty;

        /// <summary>
        /// 列情報
        /// </summary>
        public List<ColumnDataModel> Columnes { get; }

        /// <summary>
        /// テストデータ
        /// </summary>
        public List<ObjectLineModel> Data { get; }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TestMethodDataGenModel()
        {
            this.Columnes = new List<ColumnDataModel>();
            this.Data = new List<ObjectLineModel>();
        }
        #endregion

        #region
        
        /// <summary>
        /// 列名の返却
        /// </summary>
        /// <param name="columnNo">列番号</param>
        /// <returns>列名</returns>
        public string GetColumnName(int columnNo)
        {
            var target=Columnes.Where(record => record.ColumnNo == columnNo)
                .FirstOrDefault();

            if(target==null)
            {
                return string.Empty;
            }

            return target.ColumnName;
        }

        public string GetColumnType(int columnNo)
        {
            var target = Columnes.Where(record => record.ColumnNo == columnNo)
                .FirstOrDefault();

            if (target == null)
            {
                return string.Empty;
            }

            return target.Type;
        }

        #endregion
    }
}

