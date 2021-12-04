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

        public int BlogId { get; set; }

        public int GenderId { get; set; }
    }

    public class BlogInIndexViewModel
    {
        public string Title { get; set; }

        public string Writer { get; set; }

        public string CategoryTitle { get; set; }

        public int BlogId { get; set; }

        public string ImageName { get; set; }
    }

    public class BlogInBlogIndexViewModel
    {
        public string Title { get; set; }

        public string Writer { get; set; }

        public string CategoryTitle { get; set; }

        public int BlogId { get; set; }

        public string ImageName { get; set; }

        public DateTime BlogCreateDate { get; set; }

        public int GenderId { get; set; }

        public string MiniDescription { get; set; }
    }

    public class RelatedBlogViewModel
    {
        public int BlogId { get; set; }

        public int CatId { get; set; }

        public string Title { get; set; }

        public string ImageName { get; set; }

        public DateTime BlogCreateDate { get; set; }

        public string CategoryTitle { get; set; }
    }
}
