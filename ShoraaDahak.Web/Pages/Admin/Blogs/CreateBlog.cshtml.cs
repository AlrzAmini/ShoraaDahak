using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.Blog;

namespace ShoraaDahak.Web.Pages.Admin.Blogs
{
    public class CreateBlogModel : PageModel
    {
        private readonly IBlogService _blogService;

        public CreateBlogModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [BindProperty]
        public Blog Blog { get; set; }

        public IActionResult OnGet()
        {
            #region Fill Drop Downs

            var categories = _blogService.GetCategories();
            ViewData["Category"] = new SelectList(categories, "Value", "Text");

            var subCat = _blogService.GetSubCats(int.Parse(categories.First().Value));
            ViewData["SubCat"] = new SelectList(subCat, "Value", "Text");

            var writer = _blogService.GetWriters();
            ViewData["Writer"] = new SelectList(writer, "Value", "Text");

            var gender = _blogService.GetGenders();
            ViewData["Gender"] = new SelectList(gender, "Value", "Text");


            #endregion

            return Page();
        }

        public IActionResult OnPost(IFormFile imgBlogUp)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _blogService.AddBlog(Blog,imgBlogUp);

            return RedirectToPage("Index");
        }
    }
}
