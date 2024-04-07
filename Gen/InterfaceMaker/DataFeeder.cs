using ClosedXML.Excel;
using DocumentFormat.OpenXml.EMMA;
using InterfaceMaker.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMaker
{
    /// <summary>
    /// データモデル定義書からの読み取りを行います
    /// </summary>
    public static class DataFeeder
    {
        /// <summary>
        /// データモデルから読み取ってInterfaceの材料を作ります
        /// </summary>
        /// <param name="path">仕様書のパス</param>
        /// <returns>Interfaceの材料</returns>
        public static MaterialDataModel CreateMaterial(string path)
        {
            const int PROPERTY_START = 17;
            const int COMMENT_ROW = 5;
            const string COMMENT_COL = "AA";

            const int CLASS_ROW = 4;
            const string CLASS_COL = "AA";
            const string NO_COL = "B";
            const string COMMENT_PROP_COL = "G";
            const string NAME_PROP_COL = "V";
            const string TYPE_PROP_COL = "AK";


            MaterialDataModel materialDataModel = new MaterialDataModel();

            //データモデル定義書の今読んでる行
            int row = 17;

            //データモデル定義書を読み込む
            using (XLWorkbook workbook = new XLWorkbook(path))
            {
                if (workbook == null)
                {
                    throw new Exception("データモデル定義書が不正です");
                }

                if (workbook.Worksheets==null)
                {
                    throw new Exception("データモデル定義書が不正です");
                }

                //データモデル定義書の最初のシートに書いてある。
                var sheet = workbook.Worksheets.First();
                //コメントをセットする。
                materialDataModel.Comment = sheet.Cell(COMMENT_ROW, COMMENT_COL).Value.ToString();
                //クラス名をセットする。
                materialDataModel.ClassName = sheet.Cell(CLASS_ROW, CLASS_COL).Value.ToString();

                //プロパティが定義されてる行い移動
                row = PROPERTY_START;

                //プロパティの番号がある限り
                string no = "";
                while (true)
                {
                    no=sheet.Cell(row,NO_COL).Value.ToString();
                    if (string.IsNullOrEmpty(no))
                    {
                        break;
                    }

                    PropertyInfo info = new PropertyInfo();
                    //コメント
                    info.Comment= sheet.Cell(row, COMMENT_PROP_COL).Value.ToString();
                    //型
                    info.Type=sheet.Cell(row, TYPE_PROP_COL).Value.ToString();

                    if(info.Type.Contains("List<"))
                    {
                        info.IsList = true;
                    }

                    if (info.Type.Contains("_R"))
                    {
                        info.IsRead = true;
                    }

                    //プロパティ
                    info.Name = sheet.Cell(row, NAME_PROP_COL).Value.ToString();
                    materialDataModel.Propertys.Add(info);
                    row++;
                }
            }
            return materialDataModel;
        }
    }
}
