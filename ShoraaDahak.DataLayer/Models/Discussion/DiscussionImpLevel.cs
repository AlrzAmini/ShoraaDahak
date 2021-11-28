using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoraaDahak.DataLayer.Models.Services;

namespace ShoraaDahak.DataLayer.Models.Discussion
{
    public class DiscussionImpLevel
    {
        [Key]
        public int ImpLevelId { get; set; }

        [DisplayName("میزان اهمیت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string ImpLevelTitle { get; set; }


        #region Relations

        public List<Discussion> Discussions { get; set; }

        #endregion
    }
}
