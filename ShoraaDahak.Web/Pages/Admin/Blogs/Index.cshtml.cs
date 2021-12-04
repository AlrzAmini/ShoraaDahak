using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoraaDahak.Core.Consts;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.Core.Services.Interfaces;

namespace ShoraaDahak.Web.Pages.Admin.Blogs
{
    public class IndexModel : PageModel
    {
        private readonly IBlogService _blogService;

        public IndexModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public List<BlogsForAdminIndexViewModel> Blogs { get; set; }

        public IActionResult OnGet()
        {
            Blogs = _blogService.GetBlogsForShowInIndexAdmin();

            ViewData["BlogByMans"] = Blogs.Count(b => b.GenderId == Gender.Man);
            ViewData["BlogByWomen"] = Blogs.Count(b => b.GenderId == Gender.Woman);

            return Page();
        }

        public IActionResult OnGetDeleteBlog(int id)
        {
            _blogService.DeleteBlog(id);

            return RedirectToPage("Index");
        }
    }
}
