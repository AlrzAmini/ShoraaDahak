using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoraaDahak.Core.Services.Interfaces;

namespace ShoraaDahak.Web.ViewComponents
{
    public class BlogCategoryComponent : ViewComponent
    {
        private readonly IBlogService _blogService;

        public BlogCategoryComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("BlogCategory", _blogService.GetAllBlogCategories()));
        }
    }
}
