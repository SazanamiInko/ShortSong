using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenBLayer.DataMpdels
{
    /// <summary>
    ///  テストオブジェクト
    /// </summary>
    public class ObjectLineModel
    {
        /// <summary>
        /// オブジェクトNo
        /// </summary>
        public string ObjecctNo { get; set; }

        /// <summary>
        /// パラメータ
        /// </summary>
        public List<ParameterDataerModel> Params { get; }
    }
}
