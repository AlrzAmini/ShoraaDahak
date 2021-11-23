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
using ShoraaDahak.DataLayer.Models.User;

namespace ShoraaDahak.Web.Pages.Admin.Roles
{
    [Authorize]
    [PermissionChecker(PerIds.AdminRoles)]
    public class IndexModel : PageModel
    {
        private readonly IPermissionService _permissionService;

        public IndexModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public List<Role> Roles { get; set; }
        
        public IActionResult OnGet(int pageId=1,string filterName="",string filterNCode="")
        {
            Roles = _permissionService.GetAllRoles();
            return Page();
        }
    }
}
