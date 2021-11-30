using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoraaDahak.DataLayer.Models.Letter
{
    public class LetterTo
    {
        [Key]
        public int LetterToId { get; set; }

        [DisplayName("مقصد نامه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string LetterToTitle { get; set; }


        #region Relations

        public List<Letter> Letters { get; set; }

        #endregion
    }
}
