using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.DataModel
{
    /// <summary>
    /// お気に入り更新モデル
    /// </summary>
    public class PreferenceUpdateModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 短歌
        /// </summary>
        public string Uta { get; set; } = null!;

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; } = null!;

        /// <summary>
        /// 出典
        /// </summary>
        public string? Book { get; set; }

        /// <summary>
        /// 時代
        /// </summary>
        public string? Era { get; set; }

        /// <summary>
        /// 見出し
        /// </summary>
        public string? Index { get; set; }

        /// <summary>
        /// 備考
        /// </summary>
        public string? Memo { get; set; }

        /// <summary>
        /// 更新時間
        /// </summary>
        public string? UpdateDate { get; set; }
    }
}
