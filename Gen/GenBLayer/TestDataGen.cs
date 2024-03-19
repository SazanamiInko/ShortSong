using ClosedXML.Excel;
using GenBLayer.DataMpdels;

namespace GenBLayer
{
    /// <summary>
    /// テストデータ作成
    /// </summary>
    public class TestDataGen
    {
        #region 定数

        /// <summary>
        /// コメント行
        /// </summary>
        private const int COMMENT_ROW = 3;

        /// <summary>
        /// 列名行
        /// </summary>
        private const int COLUMNNAME_ROW = 4;

        /// <summary>
        /// タイプ列
        /// </summary>
        private const int TYPE_ROW = 5;

        /// <summary>
        /// テストラベル
        /// </summary>
        private const string TESTLABEL= "TestLabel";

        /// <summary>
        /// 開始
        /// </summary>
        private const int START_COLUMN = 2;

        /// <summary>
        /// データ開始行
        /// </summary>
        private const int START_DATA_ROW = 6;

    #endregion

    /// <summary>
    /// テストデータクラス作成
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public TestDataGenDataModel CreateTestGenDataModel(string path)
        {
            TestDataGenDataModel dm = new TestDataGenDataModel();

            //テストデータオブジェクトがファイル名

            FileInfo info= new FileInfo(path);
            dm.Target = info.Name.Replace(info.Extension, "");

            //エクセルを開く
            XLWorkbook workbook = new XLWorkbook(path);
            //シートごとに処理
            var sheets=workbook.Worksheets;
            
            foreach(var sheet in sheets) 
            {
                //メソッド名はシート名で決定
                TestMethodDataGenModel method = new TestMethodDataGenModel();
                method.MethodName = sheet.Name;
        
                int pos = START_COLUMN;

                while (true)
                {
                    //列情報を読み取り
                    string comment = sheet.Cell(COMMENT_ROW, pos).Value.ToString();
                    string columnName = sheet.Cell(COLUMNNAME_ROW, pos).Value.ToString();
                    string type= sheet.Cell(TYPE_ROW, pos).Value.ToString();
                    
                    //終わり行
                    if (comment== TESTLABEL)
                    {
                        break;
                    }

                    if(string.IsNullOrEmpty(comment))
                    {
                        break;
                    }

                    //列情報を登録
                    ColumnDataModel column = new ColumnDataModel()
                    { ColumnNo = pos, 
                      Comment = comment, 
                      ColumnName = columnName,
                      Type=type
                    };

                    method.Columnes.Add(column);
                    pos++;
                }

                int row = START_DATA_ROW;
              
                while(true)
                {
                    if (sheet.Cell(row,2).Value.ToString()==string.Empty)
                    {
                        break;
                    }

                    if (sheet.Cell(row, 2).Value.ToString() == "END")
                    {
                        break;
                    }

                    ObjectLineModel lm = new ObjectLineModel();
                    lm.ObjecctNo = sheet.Cell(row, 2).Value.ToString();
                    for (int pos_val=2;pos_val<pos;pos_val++)
                    {
                        string columnName= sheet.Cell(COLUMNNAME_ROW, pos_val).Value.ToString();
                        string type= sheet.Cell(TYPE_ROW, pos_val).Value.ToString();
                        string value=sheet.Cell(row, pos_val).Value.ToString();

                        ParameterDataerModel param = new ParameterDataerModel() 
                        {
                            ColumnNo=pos_val,
                            Value=value,
                            ColumnName=columnName,
                            Type=type
                        };
                        lm.Params.Add(param);
                    }

                    method.Data.Add(lm);
                    row++;
                }

                dm.TestGenMethods.Add(method);
            }

            return dm;
        }
    }
}
