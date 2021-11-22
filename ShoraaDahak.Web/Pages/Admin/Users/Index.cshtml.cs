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
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public UsersForAdminViewModel UsersForAdmin { get; set; }
        
        public IActionResult OnGet(int pageId=1,string filterName="",string filterNCode="")
        {
            UsersForAdmin = _userService.GetAllUsers(pageId,filterName,filterNCode);
            return Page();
        }
    }
}
