using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoraaDahak.Core.Consts;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.Core.Security;
using ShoraaDahak.Core.Services.Interfaces;

namespace ShoraaDahak.Web.Pages.Admin.Users
{
    [Authorize]
    [PermissionChecker(PerIds.AdminUsers)]
    public class DeleteUserModel : PageModel
    {
        private readonly IUserService _userService;

        public DeleteUserModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public DeleteUserViewModel DeleteUserViewModel { get; set; }

        public IActionResult OnGet(int id)
        {
            DeleteUserViewModel = _userService.GetUserForDeleteInAdmin(id);

            if (DeleteUserViewModel == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            _userService.DeleteUserFromAdmin(id);
            return RedirectToPage("Index");
        }
    }
}
