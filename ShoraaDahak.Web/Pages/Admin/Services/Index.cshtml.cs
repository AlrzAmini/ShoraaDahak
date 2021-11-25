using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoraaDahak.Core.Consts;
using ShoraaDahak.Core.Convertors;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.Core.Security;
using ShoraaDahak.Core.Services.Interfaces;

namespace ShoraaDahak.Web.Pages.Admin.Services
{
    [Authorize]
    [PermissionChecker(PerIds.AdminServices)]
    public class IndexModel : PageModel
    {
        private readonly IServiceService _serviceService;

        public IndexModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public ServicesForAdminViewModel Services { get; set; }

        public IActionResult OnGet(int pageId = 1, string filterServiceTitle = "")
        {
            Services = _serviceService.GetAllServices(pageId,filterServiceTitle);

            // Total Budget
            int totalBudget = Services.Services.Sum(s => s.ServiceBudget);
            ViewData["TotalBudget"] = totalBudget.ToToman();

            // Total Added Services
            int totalServices = Services.Services.Count;
            ViewData["TotalServices"] = totalServices;

            return Page();
        }
    }
}
