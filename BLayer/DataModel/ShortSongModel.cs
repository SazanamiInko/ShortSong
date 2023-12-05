using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.DataModel
{
    /// <summary>
    /// 短歌モデル
    /// </summary>
    public class ShortSongModel
    {
        public long Id { get; set; }

        public string Front { get; set; }

        public string Uta { get; set; } = null!;

        public string Kana { get; set; } = null!;

        public string? English { get; set; }

        public string? Index { get; set; }

        public string? Memo { get; set; }

        public long Seazon { get; set; }

        public string CreateDate { get; set; } = null!;

        public long Delete { get; set; }

        public string? RefUta { get; set; }
    }
}
