using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.Core.Services.Interfaces;

namespace ShoraaDahak.Web.Pages.Admin.Users
{
    public class CreateUserModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IPermissionService _permissionService;

        public CreateUserModel(IUserService userService, IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }

        [BindProperty]
        public CreateUserViewModel CreateUser { get; set; }

        public IActionResult OnGet()
        {
            ViewData["Roles"] = _permissionService.GetAllRoles();
            return Page();
        }

        public IActionResult OnPost(List<int> SelectedRoles)
        {
            #region Validation

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_userService.IsNCodeExist(CreateUser.NCode))
            {
                ModelState.AddModelError("", "این کد ملی قبلا استفاده شده است.");
                ViewData["IsNCodeUniq"] = "false";
                return Page();
            }

            if (_userService.IsEmailExist(CreateUser.Email))
            {
                ModelState.AddModelError("", "این ایمیل قبلا استفاده شده است.");
                ViewData["IsEmailUniq"] = "false";
                return Page();
            }

            if (SelectedRoles == null)
            {
                ModelState.AddModelError("", "لطفا تمامی فبلد های قرار گرفته را پر کنید");
            }

            #endregion

            // add user
            int userId = _userService.AddUserFromAdmin(CreateUser);

            // add roles to user
            _permissionService.AddRolesToUser(SelectedRoles,userId);
            
            return RedirectToPage("Index");
        }
    }
}
