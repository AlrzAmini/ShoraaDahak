using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoraaDahak.DataLayer.Models.Services;

namespace ShoraaDahak.DataLayer.Models.User
{
    public class User
    {
        public User()
        {

        }

        #region UserId

        [Key]
        public int UserId { get; set; }

        #endregion

        #region Name

        [DisplayName("نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string Name { get; set; }

        #endregion

        #region National Code

        [DisplayName("کد ملی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string NCode { get; set; }

        #endregion

        #region Phone Number

        [DisplayName("شماره تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string PhoneNumber { get; set; }

        #endregion

        #region Birth Date

        [DisplayName("تاریخ تولد")]
        public DateTime BirthDate { get; set; }

        #endregion

        #region Email

        [DisplayName("ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(400, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نیست !")]
        public string Email { get; set; }

        #endregion

        #region Password

        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string Password { get; set; }

        #endregion

        #region Active Code

        [DisplayName("کد فعالسازی")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string ActivationCode { get; set; }

        #endregion

        #region IsActive

        [DisplayName("وضعیت فعالسازی")]
        public bool IsActive { get; set; }

        #endregion

        #region Register Date

        [DisplayName("تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; }

        #endregion

        [DisplayName("وضعیت تایید")]
        public bool IsConfirmedByAdmin { get; set; }

        #region Relations

        public List<UserRole> UserRoles { get; set; }

        public List<Service> Services { get; set; }

        public List<Discussion.Discussion> Discussions { get; set; }


        #endregion

    }
}
