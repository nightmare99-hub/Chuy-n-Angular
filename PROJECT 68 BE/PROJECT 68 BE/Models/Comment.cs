using System;
using System.Collections.Generic;

namespace PROJECT_68_BE.Models
{
    public partial class Comment
    {
        public Comment()
        {
            Animes = new HashSet<Animes>();
        }

        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime? CmtDate { get; set; }
        public int? ViewerId { get; set; }

        public virtual Viewer Viewer { get; set; }
        public virtual ICollection<Animes> Animes { get; set; }
    }
}
