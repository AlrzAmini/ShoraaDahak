using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.User;

namespace ShoraaDahak.Web.Pages.Admin.Users
{
    public class EditUserModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IPermissionService _permissionService;

        public EditUserModel(IUserService userService, IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }

        [BindProperty]
        public EditUserViewModel EditUser { get; set; }
        [BindProperty]
        public List<Role> Roles { get; set; }

        public IActionResult OnGet(int id)
        {
            EditUser = _userService.GetUserForEditInAdmin(id);
            Roles = _permissionService.GetAllRoles();
            return Page();
        }

        public IActionResult OnPost(List<int> SelectedRoles)
        {
            #region Validation

            if (!ModelState.IsValid)
            {
                return Page();
            }

            #endregion

            _userService.EditUserFromAdmin(EditUser);

            _permissionService.EditRolesUser(SelectedRoles,EditUser.UserId);

            return RedirectToPage("Index");
        }
    }
}
