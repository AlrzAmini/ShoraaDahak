using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoraaDahak.DataLayer.Models.Discussion
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }

        [Required]
        public int DiscussionId { get; set; }

        public int? UserId { get; set; }


        [DisplayName("متن پاسخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string AnswerBody { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }



        #region Relations

        [ForeignKey("DiscussionId")]
        public Discussion Discussion { get; set; }

        [ForeignKey("UserId")]
        public User.User User { get; set; }

        #endregion
    }
}
