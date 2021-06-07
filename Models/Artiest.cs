using System;
using System.Collections.Generic;

#nullable disable

namespace testje_amk.Models
{
    public partial class Artiest
    {
        public Artiest()
        {
            Songs = new HashSet<Song>();
        }

        public int Artiestid { get; set; }
        public string Naam { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
