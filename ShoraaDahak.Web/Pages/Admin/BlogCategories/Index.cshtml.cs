using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.Blog;

namespace ShoraaDahak.Web.Pages.Admin.BlogCategories
{
    public class IndexModel : PageModel
    {
        private readonly IBlogService _blogService;

        public IndexModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public List<BlogCategory> Categories { get; set; }

        public IActionResult OnGet()
        {
            Categories = _blogService.GetAllBlogCategories();
            return Page();
        }

        public IActionResult OnGetDelete(int id)
        {
            _blogService.DeleteBlogCategory(id);

            return RedirectToPage("Index");
        }
    }
}
