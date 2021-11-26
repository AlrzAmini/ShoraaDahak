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

namespace ShoraaDahak.Web.Pages.Admin.Services
{
    [Authorize]
    [PermissionChecker(PerIds.AdminServices)]
    public class DeleteServiceModel : PageModel
    {
        private readonly IServiceService _serviceService;

        public DeleteServiceModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [BindProperty]
        public ServiceInAdminForDelete Service { get; set; }

        public IActionResult OnGet(int id)
        {
            Service = _serviceService.GetServiceForDelete(id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            _serviceService.DeleteService(id);

            return RedirectToPage("Index");
        }
    }
}
