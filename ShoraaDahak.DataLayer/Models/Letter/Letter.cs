using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoraaDahak.DataLayer.Models.Discussion;
using ShoraaDahak.DataLayer.Models.Services;

namespace ShoraaDahak.DataLayer.Models.Letter
{
    public class Letter
    {
        [Key]
        public int LetterId { get; set; }

        [Required]
        public int LetterToId { get; set; }

        [Required]
        public int SenderId { get; set; }

        [DisplayName("موضوع نامه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(400, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string LetterTitle { get; set; }

        [DisplayName("متن نامه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string LetterBody { get; set; }

        [Required]
        public DateTime LetterSendDate { get; set; }

        [DisplayName("فایل ضمیمه")]
        [MaxLength(50)]
        public string LetterFileName { get; set; }

        public bool IsRead { get; set; }


        #region Relations

        [ForeignKey("LetterToId")]
        public LetterTo LetterTo { get; set; }

        [ForeignKey("SenderId")]
        public User.User User { get; set; }

        public List<LetterAnswer> LetterAnswers { get; set; }

        #endregion
    }
}
