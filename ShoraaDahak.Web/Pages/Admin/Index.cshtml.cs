using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoraaDahak.Core.Consts;
using ShoraaDahak.Core.Security;

namespace ShoraaDahak.Web.Pages.Admin
{
    [Authorize]
    [PermissionChecker(PerIds.AdminPanel)]
    public class IndexModel : PageModel
    {
        public string Name { get; set; }

        public IActionResult OnGet()
        {
            Name = User.Identity.Name;
            return Page();
        }
    }
}
