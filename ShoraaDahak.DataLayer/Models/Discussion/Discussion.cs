using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoraaDahak.DataLayer.Models.Services;

namespace ShoraaDahak.DataLayer.Models.Discussion
{
    public class Discussion
    {
        [Key]
        public int DiscussionId { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [Required]
        public int ImpLevelId { get; set; }

        public int? UserId { get; set; }

        [DisplayName("عنوان بحث")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string DiscussionTitle { get; set; }

        [DisplayName("متن بحث")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string DiscussionBody { get; set; }

        [Required]
        public DateTime DiscussionCreateDate { get; set; }


        #region Relations

        [ForeignKey("ImpLevelId")]
        public DiscussionImpLevel DiscussionImpLevel { get; set; }

        [ForeignKey("UserId")]
        public User.User User { get; set; }

        [ForeignKey("ServiceId")]
        public Service Service { get; set; }

        public List<Answer> Answers { get; set; }

        #endregion
    }
}
