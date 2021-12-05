using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoraaDahak.DataLayer.Models.Blog
{
    public class CommentAnswer
    {
        [Key]
        public int CAnswerId { get; set; }

        [Required]
        public int CommentId { get; set; }

        public int? UserId { get; set; }

        [DisplayName("متن پاسخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(800, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string AnswerBody { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }



        #region Relations

        [ForeignKey("CommentId")]
        public Comment Comment { get; set; }

        [ForeignKey("UserId")]
        public User.User User { get; set; }

        #endregion
    }
}
