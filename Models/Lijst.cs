using System;
using System.Collections.Generic;

#nullable disable

namespace testje_amk.Models
{
    public partial class Lijst
    {
        public int Songid { get; set; }
        public int Top2000jaar { get; set; }
        public int Positie { get; set; }

        public virtual Song Song { get; set; }
        public virtual Top2000Jaar Top2000jaarNavigation { get; set; }
    }
}
