using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoraaDahak.DataLayer.Models.Services
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        [Required]
        public int GroupId { get; set; }

        public int? SubGroup { get; set; }

        [Required]
        public int WriterId { get; set; }

        [Required]
        public int StatusId { get; set; }

        #region Service Properties

        [DisplayName("عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(250, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string ServiceTitle { get; set; }

        [DisplayName("شرح خدمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string ServiceDescription { get; set; }

        [DisplayName("تاریخ شروع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public DateTime ServiceStartDate { get; set; }

        [DisplayName("تاریخ پایان")]
        public DateTime? ServiceEndDate { get; set; }

        [DisplayName("آخرین بروزرسانی")]
        public DateTime? ServiceUpdateDate { get; set; }

        [DisplayName("بودجه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public int ServiceBudget { get; set; }

        [DisplayName("نهاد های مربوطه")]
        [MaxLength(500, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string RelatedInstitutions { get; set; }

        [DisplayName("ویدیو کوتاه")]
        [MaxLength(100)]
        public string ServiceVideoName { get; set; }

        [DisplayName("تصویر")]
        [MaxLength(50)]
        public string ServiceImageName { get; set; }


        #endregion



        #region Relations

        [ForeignKey("GroupId")]
        public ServiceGroup ServiceGroup { get; set; }

        [ForeignKey("SubGroup")]
        public ServiceGroup Grooup { get; set; }

        [ForeignKey("WriterId")]
        public User.User User { get; set; }

        [ForeignKey("StatusId")]
        public ServiceStatus ServiceStatus { get; set; }

        public List<Discussion.Discussion> Discussions { get; set; }


        #endregion

    }
}
