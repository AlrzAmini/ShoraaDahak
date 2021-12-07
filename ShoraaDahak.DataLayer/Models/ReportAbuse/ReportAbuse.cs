using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoraaDahak.DataLayer.Models.ReportAbuse
{
    public class ReportAbuse
    {
        [Key]
        public int ReportId { get; set; }

        [Required]
        public int UserId { get; set; }

        [DisplayName("موضوع گزارش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(400, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string ReportSubject { get; set; }

        [DisplayName("توضیحات گزارش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(850, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string ReportDescription { get; set; }

        [DisplayName("آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(500, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string ReportAddress { get; set; }

        [DisplayName("تاریخ ثبت")]
        [Required]
        public DateTime CreateDate { get; set; }

        public bool IsRead { get; set; }


        #region Relation

        [ForeignKey("UserId")]
        public User.User User { get; set; }

        #endregion
    }
}
