using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoraaDahak.DataLayer.Models.User;

namespace ShoraaDahak.DataLayer.Models.Permission
{
    public class RolePermission
    {
        [Key]
        public int RolePrmId { get; set; }

        public int RoleId { get; set; }

        public int PermissionId { get; set; }


        #region Relations

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        [ForeignKey("PermissionId")]
        public Permission Permission { get; set; }

        #endregion

    }
}
