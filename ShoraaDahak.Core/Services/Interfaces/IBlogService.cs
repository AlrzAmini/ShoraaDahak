using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.DataLayer.Models.Blog;

namespace ShoraaDahak.Core.Services.Interfaces
{
    public interface IBlogService
    {
        #region Category

        List<BlogCategory> GetAllBlogCategories();

        void AddCategory(BlogCategory blogCategory);

        BlogCategory GetBlogCategoryById(int id);

        void UpdateBlogCategory(BlogCategory blogCategory);

        void DeleteBlogCategory(int id);

        #endregion

        #region Blog

        List<SelectListItem> GetCategories();

        List<SelectListItem> GetSubCats(int catId);

        List<SelectListItem> GetWriters();

        List<SelectListItem> GetGenders();

        void AddBlog(Blog blog,IFormFile imgBlog);

        List<BlogsForAdminIndexViewModel> GetBlogsForShowInIndexAdmin();

        void DeleteBlog(int blogId);

        Blog GetBlogById(int blogId);

        #endregion

    }
}
