using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoraaDahak.DataLayer.Models.Permission;

namespace ShoraaDahak.DataLayer.Models.User
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [DisplayName("عنوان نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیش از {1} کاراکتر داشته باشد")]
        public string RoleTitle { get; set; }


        #region Relations

        public List<UserRole> UserRoles { get; set; }

        public List<RolePermission> RolePermissions { get; set; }

        #endregion
    }
}
