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
}
