using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoraaDahak.DataLayer.Models.Letter
{
    public class LetterAnswer
    {
        [Key]
        public int LetterAnswerId { get; set; }

        [Required]
        public int LetterId { get; set; }

        public int? SenderId { get; set; }


        [DisplayName("متن پاسخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string LetterAnswerBody { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }



        #region Relations

        [ForeignKey("LetterId")]
        public Letter Letter { get; set; }

        [ForeignKey("SenderId")]
        public User.User User { get; set; }

        #endregion

    }
}
