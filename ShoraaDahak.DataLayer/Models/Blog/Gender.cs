using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoraaDahak.DataLayer.Models.Blog
{
    public class Gender
    {
        [Key]
        public int GenderId { get; set; }

        [Required]
        [MaxLength(50)]
        public string GenderTitle { get; set; }



        #region Relations

        public List<Blog> Blogs { get; set; }

        #endregion
    }
}
