using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoraaDahak.DataLayer.Models.Services
{
    public class ServiceStatus
    {
        [Key]
        public int StatusId { get; set; }

        [DisplayName("")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(150, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string StatusTitle { get; set; }


        #region Relations

        public List<Service> Services { get; set; }

        #endregion
    }
}
