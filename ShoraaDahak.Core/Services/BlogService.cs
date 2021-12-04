using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoraaDahak.Core.Consts;
using ShoraaDahak.Core.Convertors;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.Core.Generators;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Context;
using ShoraaDahak.DataLayer.Models.Blog;

namespace ShoraaDahak.Core.Services
{
    public class BlogService : IBlogService
    {
        private readonly ShooraDahakContext _context;

        public BlogService(ShooraDahakContext context)
        {
            _context = context;
        }

        public void AddBlog(Blog blog, IFormFile imgBlog)
        {
            blog.CreateDate = DateTime.Now;

            #region Add And Check Image 

            if (imgBlog != null)
            {
                blog.BlogImageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(imgBlog.FileName);

                string imgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/image", blog.BlogImageName);

                using (var stream = new FileStream(imgPath, FileMode.Create))
                {
                    imgBlog.CopyTo(stream);
                }
            }

            #endregion

            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }

        public void AddCategory(BlogCategory blogCategory)
        {
            _context.BlogCategories.Add(blogCategory);
            _context.SaveChanges();
        }

        public void DeleteBlog(int blogId)
        {
            var blog = GetBlogById(blogId);

            // Delete Image
            if (blog.BlogImageName != null)
            {
                string imgDeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/image",
                        blog.BlogImageName);

                if (File.Exists(imgDeletePath))
                {
                    File.Delete(imgDeletePath);
                }
            }

            _context.Blogs.Remove(blog);
            _context.SaveChanges();
        }

        public void DeleteBlogCategory(int id)
        {
            var category = GetBlogCategoryById(id);

            category.IsDelete = true;

            UpdateBlogCategory(category);
        }

        public List<BlogCategory> GetAllBlogCategories()
        {
            return _context.BlogCategories.ToList();
        }

        public Blog GetBlogById(int blogId)
        {
            return _context.Blogs.SingleOrDefault(b => b.BlogId == blogId);
        }

        public BlogCategory GetBlogCategoryById(int id)
        {
            return _context.BlogCategories.Find(id);
        }

        public Blog GetBlogForShowById(int id)
        {
            return _context.Blogs
                .Include(b => b.User)
                .Include(b => b.BlogCategory)
                .FirstOrDefault(b => b.BlogId == id);
        }

        public List<BlogsForAdminIndexViewModel> GetBlogsForShowInIndexAdmin()
        {
            return _context.Blogs
                .Include(b => b.BlogCategory)
                .Include(b => b.User)
                .Select(b => new BlogsForAdminIndexViewModel()
                {
                    Category = b.BlogCategory.BlogCategoryTitle,
                    MiniDescription = b.LittleDescription,
                    Title = b.BlogTitle,
                    Writer = b.User.Name,
                    BlogId = b.BlogId,
                    GenderId = b.GenderId
                }).ToList();
        }

        public List<BlogInBlogIndexViewModel> GetBlogsInBlogIndex(int pageNum = 1, List<int> categories = null, string searchBlog = "", int take = 0)
        {
            IQueryable<Blog> result = _context.Blogs;

            if (categories != null && categories.Any())
            {
                foreach (int catId in categories)
                {
                    result = result.Where(s => s.CategoryId == catId || s.SubCatId == catId);
                }
            }

            if (!string.IsNullOrEmpty(searchBlog))
            {
                result = result.Where(r => r.BlogTitle.Contains(searchBlog));
            }

            if (take == 0)
            {
                take = 9;
            }

            take = Pagings.TakeBlogInIndex;
            int skip = (pageNum - 1) * take;

            return result
                 .Include(b => b.BlogCategory)
                 .Include(b => b.User)
                 .Select(b => new BlogInBlogIndexViewModel()
                 {
                     BlogCreateDate = b.CreateDate,
                     BlogId = b.BlogId,
                     CategoryTitle = b.BlogCategory.BlogCategoryTitle,
                     GenderId = b.GenderId,
                     ImageName = b.BlogImageName,
                     MiniDescription = b.LittleDescription,
                     Title = b.BlogTitle,
                     Writer = b.User.Name
                 }).Skip(skip).Take(take).ToList();

        }

        public List<BlogInIndexViewModel> GetBlogsInIndex()
        {
            return _context.Blogs
                .Include(b => b.BlogCategory)
                .Include(b => b.User)
                .Select(b => new BlogInIndexViewModel()
                {
                    Title = b.BlogTitle,
                    Writer = b.User.Name,
                    CategoryTitle = b.BlogCategory.BlogCategoryTitle,
                    BlogId = b.BlogId,
                    ImageName = b.BlogImageName
                }).ToList();
        }

        public List<SelectListItem> GetCategories()
        {
            return _context.BlogCategories.Where(c => c.ParrentId == null)
                .Select(c => new SelectListItem()
                {
                    Value = c.BlogCategoryId.ToString(),
                    Text = c.BlogCategoryTitle
                }).ToList();
        }

        public List<SelectListItem> GetGenders()
        {
            return _context.Genders.Select(g => new SelectListItem()
            {
                Value = g.GenderId.ToString(),
                Text = g.GenderTitle
            }).ToList();
        }

        public List<RelatedBlogViewModel> GetRelatedBlogsByCatId(int catId)
        {
            return _context.Blogs
                .Include(b => b.BlogCategory)
                .Where(b => b.CategoryId == catId)
                .Select(b => new RelatedBlogViewModel()
                {
                    Title = b.BlogTitle,
                    BlogCreateDate = b.CreateDate,
                    BlogId = b.BlogId,
                    CatId = b.CategoryId,
                    CategoryTitle = b.BlogCategory.BlogCategoryTitle,
                    ImageName = b.BlogImageName
                }).ToList();
        }

        public List<SelectListItem> GetSubCats(int catId)
        {
            return _context.BlogCategories.Where(c => c.ParrentId == catId)
                .Select(c => new SelectListItem()
                {
                    Value = c.BlogCategoryId.ToString(),
                    Text = c.BlogCategoryTitle
                }).ToList();
        }

        public List<SelectListItem> GetWriters()
        {
            return _context.UserRoles.Where(u => u.RoleId == 12)
                .Include(u => u.User)
                .Select(u => new SelectListItem()
                {
                    Value = u.UserId.ToString(),
                    Text = u.User.Name
                }).ToList();
        }

        public void UpdateBlog(Blog blog, IFormFile imgBlog)
        {

            #region Edit Image

            if (imgBlog != null)
            {
                // Delete it
                string imgDeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/image",
                        blog.BlogImageName);
                if (File.Exists(imgDeletePath))
                {
                    File.Delete(imgDeletePath);
                }

                // Create New Image
                blog.BlogImageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(imgBlog.FileName);
                string imgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/image", blog.BlogImageName);

                using (var stream = new FileStream(imgPath, FileMode.Create))
                {
                    imgBlog.CopyTo(stream);
                }
            }

            #endregion

            blog.CreateDate = DateTime.Now;

            _context.Blogs.Update(blog);
            _context.SaveChanges();
        }

        public void UpdateBlogCategory(BlogCategory blogCategory)
        {
            _context.BlogCategories.Update(blogCategory);
            _context.SaveChanges();
        }
    }
}
