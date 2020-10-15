using System;
using System.Collections.Generic;

namespace PROJECT_68_BE.Models
{
    public partial class AirDate
    {
        public AirDate()
        {
            Animes = new HashSet<Animes>();
        }

        public int AirDateId { get; set; }
        public string AirDateName { get; set; }

        public virtual ICollection<Animes> Animes { get; set; }
    }
}
