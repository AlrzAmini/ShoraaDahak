using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoraaDahak.Core.DTOs
{
    public class BlogsForAdminIndexViewModel
    {
        public string Title { get; set; }

        public string Writer { get; set; }

        public string MiniDescription { get; set; }

        public string Category { get; set; }

        public string CreateDate { get; set; }

        public int BlogId { get; set; }
    }
}
