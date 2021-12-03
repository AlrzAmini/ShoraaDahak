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
    public class EditBlogCategoryModel : PageModel
    {
        private readonly IBlogService _blogService;

        public EditBlogCategoryModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [BindProperty]
        public BlogCategory Category { get; set; }

        public IActionResult OnGet(int id)
        {
            Category = _blogService.GetBlogCategoryById(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _blogService.UpdateBlogCategory(Category);

            return RedirectToPage("Index");

        }
    }
}
