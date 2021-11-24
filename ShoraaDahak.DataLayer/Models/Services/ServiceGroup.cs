using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoraaDahak.DataLayer.Models.Services
{
    public class ServiceGroup
    {
        [Key]
        public int GroupId { get; set; }

        [DisplayName("عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string GroupTitle { get; set; }

        [DisplayName("گروه اصلی")]
        public int? ParrentId { get; set; }


        #region Relations

        [ForeignKey("ParrentId")]
        public List<ServiceGroup> ServiceGroups { get; set; }

        [InverseProperty("ServiceGroup")]
        public List<Service> Services { get; set; }

        [InverseProperty("Grooup")]
        public List<Service> SubServices { get; set; }

        #endregion
    }
}
