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
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public int BlogId { get; set; }

        public int? UserId { get; set; }


        [DisplayName("متن نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(800, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string CommentBody { get; set; }

        [Required]
        public DateTime CommentCreateDate { get; set; }

        public bool IsDelete { get; set; }



        #region Relations

        [ForeignKey("BlogId")]
        public Blog Blog { get; set; }

        [ForeignKey("UserId")]
        public User.User User { get; set; }

        public List<CommentAnswer> Answers { get; set; }

        #endregion
    }
}
