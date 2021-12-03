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
    public class CreateBlogCategoryModel : PageModel
    {
        private readonly IBlogService _blogService;

        public CreateBlogCategoryModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [BindProperty]
        public BlogCategory BlogCategory { get; set; }

        public IActionResult OnGet(int? id)
        {
            BlogCategory = new BlogCategory()
            {
                ParrentId = id
            };

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _blogService.AddCategory(BlogCategory);

            return RedirectToPage("Index");
        }
    }
}
