using System;
using System.Collections.Generic;

namespace PROJECT_68_BE.Models
{
    public partial class Animes
    {
        public int AnimeId { get; set; }
        public int? StudioId { get; set; }
        public string AnimeName { get; set; }
        public int? EpsodesTotal { get; set; }
        public int AnimeTypeId { get; set; }
        public int AirDateId { get; set; }
        public int? ViewCount { get; set; }
        public byte? Status { get; set; }
        public int? CommentId { get; set; }
        public string AnimeImg { get; set; }
        public string AnimeSource { get; set; }

        public virtual AirDate AnimeType { get; set; }
        public virtual AnimeType AnimeTypeNavigation { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual Studio Studio { get; set; }
    }
}
