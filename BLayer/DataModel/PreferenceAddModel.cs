using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.DataModel
{
    public class PreferenceAddModel
    {
        

        public string Uta { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string? Book { get; set; }

        public string? Era { get; set; }

        public string? Index { get; set; }

        public string? Memo { get; set; }

        public string? CreateDate { get; set; }
    }
}
