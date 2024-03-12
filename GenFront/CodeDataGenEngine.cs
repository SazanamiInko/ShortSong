using GenBLayer.DataMpdels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFront
{
    partial class DataGenEngine
    {
        /// <summary>
        /// テストデータモデル
        /// </summary>
        private TestDataGenDataModel mode;

        /// <summary>
        /// 隠すコンストラクタ
        /// </summary>
        private DataGenEngine() { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode"></param>
        public DataGenEngine(TestDataGenDataModel mode)
        {
            this.mode = mode;
        }
    }
}
