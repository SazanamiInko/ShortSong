using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.DataModel
{
    public class HaikuModel
    {
        public long Id { get; set; }

        public string Front { get; set; }

        public string Haiku { get; set; } = null!;

        public string Kana { get; set; } = null!;

        public string? English { get; set; }

        public string? Memo { get; set; }

        public long Seazon { get; set; }

        public string CreateDate { get; set; } = null!;

        public long Delete { get; set; }

    }
}
