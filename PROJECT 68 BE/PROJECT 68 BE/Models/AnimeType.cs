using System;
using System.Collections.Generic;

namespace PROJECT_68_BE.Models
{
    public partial class AnimeType
    {
        public AnimeType()
        {
            Animes = new HashSet<Animes>();
        }

        public int AnimeTypeId { get; set; }
        public string AnimeTypeName { get; set; }
        public string AnimeTypeDescription { get; set; }

        public virtual ICollection<Animes> Animes { get; set; }
    }
}
