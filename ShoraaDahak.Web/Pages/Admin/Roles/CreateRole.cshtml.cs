using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoraaDahak.Core.Consts;
using ShoraaDahak.Core.Security;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.User;

namespace ShoraaDahak.Web.Pages.Admin.Roles
{
    [Authorize]
    [PermissionChecker(PerIds.AdminRoles)]
    public class CreateRoleModel : PageModel
    {
        private readonly IPermissionService _permissionService;

        public CreateRoleModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public Role Role { get; set; }

        public IActionResult OnGet()
        {
            ViewData["Permissions"] = _permissionService.GetAllPermissions();
            return Page();
        }

        public IActionResult OnPost(List<int> SelectedPermission)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // add role and return role id
            int roleId = _permissionService.AddRole(Role);

            // add permission to role
            _permissionService.AddPermissionsToRole(roleId, SelectedPermission);

            return RedirectToPage("./Index");
        }
    }
}
