using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ganss.XSS;
using Microsoft.AspNetCore.Authorization;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.Blog;
using ShoraaDahak.DataLayer.Models.Discussion;

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

            return View("ShowComment", _commentService.GetCommentsByBlogId(comment.BlogId));
        }

        public IActionResult ShowComment(int id, int pageNum = 1) // id = blogId
        {
            return View(_commentService.GetCommentsByBlogId(id, pageNum));
        }

        #region Delete Comment

        [Authorize]
        public IActionResult DeleteComment(int id,int blogId) // id = comment id
        {
            _commentService.DeleteCommentById(id);

            return Redirect("/Blogs/" + blogId);
        }

        #endregion

        #region Answer Comment

        [Authorize]
        public IActionResult CreateAnswer(int id, string body) // id = comment id
        {
            if (!string.IsNullOrEmpty(body))
            {
                var sanitizer = new HtmlSanitizer();
                body = sanitizer.Sanitize(body);

                CommentAnswer answer = new CommentAnswer()
                {
                    AnswerBody = body,
                    CommentId = id,
                    CreateDate = DateTime.Now,
                    IsDelete = false,
                    UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString())
                };

                int answerId = _commentService.AddAnswer(answer);

                int blogId = _commentService.GetBlogIdByCommentAnswerId(answerId);

                return Redirect("/Blogs/" + blogId);
            }

            return Forbid();
        }

        [Authorize]
        public IActionResult DeleteAnswer(int id , int blogId) // id = comment answer id
        {
            // way 1 :
            //int blogId = _commentService.GetBlogIdByCommentAnswerId(id);

            // way 2 :
            _commentService.DeleteAnswerById(id);

            return Redirect("/Blogs/" + blogId);
        }
        #endregion

        #endregion

    }
}
