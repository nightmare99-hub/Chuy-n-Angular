using System;
using System.Collections.Generic;

namespace PROJECT_68_BE.Models
{
    public partial class Studio
    {
        public Studio()
        {
            Animes = new HashSet<Animes>();
        }

        public int StudioId { get; set; }
        public string StudioName { get; set; }
        public string StudioDescription { get; set; }

        public virtual ICollection<Animes> Animes { get; set; }
    }
}
