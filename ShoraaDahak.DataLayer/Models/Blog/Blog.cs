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
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        [Required]
        public int GenderId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public int? SubCatId { get; set; }

        [Required]
        public int WriterId { get; set; }

        #region Props

        [DisplayName("عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(250, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string BlogTitle { get; set; }

        [DisplayName("توضیح کوتاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string LittleDescription { get; set; }

        [DisplayName("شرح")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string BlogBody { get; set; }

        [DisplayName("تاریخ ثبت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public DateTime CreateDate { get; set; }

        [DisplayName("تصویر")]
        [MaxLength(50)]
        public string BlogImageName { get; set; }

        #endregion



        #region Relations

        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }

        [ForeignKey("WriterId")]
        public User.User User { get; set; }

        [ForeignKey("CategoryId")]
        public BlogCategory BlogCategory { get; set; }

        [ForeignKey("SubCatId")]
        public BlogCategory SubCategory { get; set; }

        #endregion
    }
}
