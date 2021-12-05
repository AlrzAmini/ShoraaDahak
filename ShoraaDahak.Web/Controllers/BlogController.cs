using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.Blog;

namespace ShoraaDahak.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index(int pageNum = 1, List<int> categories = null, string searchBlog = "")
        {
            ViewBag.PageNum = pageNum;
            int totalPage = (int)Math.Ceiling((decimal)_blogService.GetBlogsInBlogIndex().Count() / 9);
            ViewBag.totalPage = totalPage;

            return View(_blogService.GetBlogsInBlogIndex(pageNum, categories, searchBlog));
        }

        [Route("Blogs/{id}")]
        public IActionResult Blogs(int id)
        {
            Blog blog = _blogService.GetBlogForShowById(id);

            if (blog == null)
            {
                return NotFound();
            }

            ViewBag.RelatedBlogs = _blogService.GetRelatedBlogsByCatId(blog.CategoryId);
            ViewBag.CurrentBlogId = blog.BlogId;

            return View(blog);
        }
    }
}
