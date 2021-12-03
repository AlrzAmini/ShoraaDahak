using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoraaDahak.DataLayer.Models.Services;

namespace ShoraaDahak.DataLayer.Models.Blog
{
    public class BlogCategory
    {
        [Key]
        public int BlogCategoryId { get; set; }

        [DisplayName("عنوان دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(250, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string BlogCategoryTitle { get; set; }

        [DisplayName("حذف شده")]
        public bool IsDelete { get; set; }

        [DisplayName("دسته بندی اصلی")]
        public int? ParrentId { get; set; }


        #region Relations

        [ForeignKey("ParrentId")]
        public List<BlogCategory> BlogCategories { get; set; }

        [InverseProperty("BlogCategory")]
        public List<Blog> Blogs { get; set; }

        [InverseProperty("SubCategory")]
        public List<Blog> SubBloges { get; set; }

        #endregion

    }
}
