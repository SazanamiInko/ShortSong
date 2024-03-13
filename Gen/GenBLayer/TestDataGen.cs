using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Wordprocessing;
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
        /// テストラベル
        /// </summary>
        private const string TESTLABEL= "TestLabel";

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
                TestMethodDataGenModel method = new TestMethodDataGenModel();
                method.MethodName = sheet.Name;
        
                int pos = 2;
                while (true)
                {
                    string comment = sheet.Cell(COMMENT_ROW, pos).Value.ToString();
                    string columnName = sheet.Cell(COLUMNNAME_ROW, pos).Value.ToString();

                    if(comment== TESTLABEL)
                    {
                        break;
                    }


                    ColumnDataModel column = new ColumnDataModel() { ColumnNo = pos, Comment = comment, ColumnName = columnName };

                    method.Columnes.Add(column);
                    pos++;
                }

                int row = 5;
              
                while(true)
                {
                    if (sheet.Cell(row,2).Value.ToString()==string.Empty)
                    {
                        break;
                    }

                    ObjectLineModel lm = new ObjectLineModel();
                    lm.ObjecctNo = sheet.Cell(row, 2).Value.ToString();
                    for (int pos_val=2;pos_val<pos;pos_val++)
                    {
                        string columnName= sheet.Cell(COLUMNNAME_ROW, pos_val).Value.ToString();
                        string value=sheet.Cell(row, pos_val).Value.ToString();
                        ParameterDataerModel param = new ParameterDataerModel() {ColumnNo=pos_val,Value=value,ColumnName=columnName };
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
