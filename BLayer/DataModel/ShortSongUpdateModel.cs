using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.DataModel
{
    public class ShortSongUpdateModel
    {
        public long Id { get; set; }

        public string Front { get; set; } = null!;

        public string Uta { get; set; } = null!;

        public string Kana { get; set; } = null!;

        public string? English { get; set; }

        public string? RefUta { get; set; }

        public long Seazon { get; set; }

        public string? Index { get; set; }

        public string? Memo { get; set; }

        public string UpdateDate { get; set; } = null!;

        public long UpdateCount { get; set; }

        public string Comment { get; set; }

    }
}
