using System;
using System.Collections.Generic;

namespace PROJECT_68_BE.Models
{
    public partial class Viewer
    {
        public Viewer()
        {
            Comment = new HashSet<Comment>();
        }

        public int ViewerId { get; set; }
        public string ViewerName { get; set; }
        public string ViewerEmail { get; set; }
        public string ViewerPassword { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
    }
}
