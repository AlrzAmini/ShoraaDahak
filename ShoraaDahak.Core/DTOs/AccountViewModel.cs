using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoraaDahak.Core.DTOs
{
    public class RegisterViewModel
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

        #region Re Password

        [DisplayName("تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        [Compare("Password",ErrorMessage = "رمز عبور و تکرار آن با هم یکسان نیستند")]
        public string RePassword { get; set; }

        #endregion
    }

    public class LoginViewModel
    {
        #region National Code

        [DisplayName("کد ملی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string NCode { get; set; }

        #endregion

        #region Password

        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string Password { get; set; }

        #endregion

        #region Remember me

        [DisplayName("مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }


        #endregion
    }

    public class ForgotPasswordViewModel
    {
        #region Email

        [DisplayName("ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(400, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نیست !")]
        public string Email { get; set; }

        #endregion
    }

    public class ResetPasswordViewModel
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

        public string ActiveCode { get; set; }
    }


}
