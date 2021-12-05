using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.Blog;

namespace ShoraaDahak.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICommentService _commentService;

        public BlogController(IBlogService blogService, ICommentService commentService)
        {
            _blogService = blogService;
            _commentService = commentService;
        }

        #region Index

        public IActionResult Index(int pageNum = 1, List<int> categories = null, string searchBlog = "")
        {
            ViewBag.PageNum = pageNum;
            int totalPage = (int)Math.Ceiling((decimal)_blogService.GetBlogsInBlogIndex().Count() / 9);
            ViewBag.totalPage = totalPage;

            return View(_blogService.GetBlogsInBlogIndex(pageNum, categories, searchBlog));
        }

        #endregion


        #region Detail Blog

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

        #endregion

        #region Blog Comment

        [Authorize]
        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            comment.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            comment.CommentCreateDate = DateTime.Now;
            comment.IsDelete = false;

            _commentService.AddComment(comment);

            return null;
        }

        public IActionResult ShowComment(int id , int pageNum = 1) // id = blogId
        {
            return View(_commentService.GetCommentsByBlogId(id,pageNum));
        }
        #endregion

    }
}
