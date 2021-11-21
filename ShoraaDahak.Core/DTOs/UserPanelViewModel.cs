using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoraaDahak.Core.DTOs
{
    public class UserInformationViewModel
    {
        public string Name { get; set; }

        public string NCode { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate  { get; set; }

        public DateTime RegisterDate  { get; set; }
    }

    public class EditUserInfoViewModel
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

        public string Email { get; set; }

        #endregion
    }

    public class ChangePasswordViewModel
    {
        #region Password

        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string Password { get; set; }

        #endregion

        #region Re Password

        [DisplayName("تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار آن با هم یکسان نیستند")]
        public string RePassword { get; set; }

        #endregion

        #region Old Password

        [DisplayName("رمز عبور فعلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string OldPassword { get; set; }

        #endregion
    }
}
