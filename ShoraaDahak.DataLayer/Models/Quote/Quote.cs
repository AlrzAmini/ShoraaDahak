using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoraaDahak.DataLayer.Models.quote
{
    public class Quote
    {
        [Key]
        public int QuoteId { get; set; }

        [DisplayName("متن نقل قول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(600, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string QuoteBody { get; set; }

        [DisplayName("گوینده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string QuoteBy { get; set; }

        [DisplayName("شغل گوینده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string QuoterJob { get; set; }

        [DisplayName("تصویر")]
        [MaxLength(50)]
        public string QuoteImageName { get; set; }
    }
}
