using System;
using System.Collections.Generic;

#nullable disable

namespace testje_amk.Models
{
    public partial class Song
    {
        public Song()
        {
            Lijsts = new HashSet<Lijst>();
        }

        public int Songid { get; set; }
        public int Artiestid { get; set; }
        public string Titel { get; set; }
        public int? Jaar { get; set; }

        public virtual Artiest Artiest { get; set; }
        public virtual ICollection<Lijst> Lijsts { get; set; }
    }
}
