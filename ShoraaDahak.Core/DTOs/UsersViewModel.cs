using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoraaDahak.DataLayer.Models.User;

namespace ShoraaDahak.Core.DTOs
{
    public class UsersForAdminViewModel
    {
        public List<User> Users { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }

    public class CreateUserViewModel
    {
        #region Name

        [DisplayName("نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string Name { get; set; }

        #endregion

        #region National Code

        [DisplayName("کد ملی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
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

        #region Roles

        //public List<int> SelectedRoles { get; set; }

        #endregion

    }

    public class EditUserViewModel
    {
        #region User Id

        public int UserId { get; set; }

        #endregion

        #region Name

        [DisplayName("نام")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string Name { get; set; }

        #endregion

        #region National Code

        [DisplayName("کد ملی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
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
        [MaxLength(400, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نیست !")]
        public string Email { get; set; }

        #endregion

        #region Password

        [DisplayName("رمز عبور")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string Password { get; set; }

        #endregion

        #region Roles

        public List<int> UserRoles { get; set; }

        #endregion

    }

    public class DeleteUserViewModel
    {
        #region User Id

        public int UserId { get; set; }

        #endregion

        #region Name

        [DisplayName("نام")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string Name { get; set; }

        #endregion

        #region National Code

        [DisplayName("کد ملی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string NCode { get; set; }

        #endregion

    }
}
