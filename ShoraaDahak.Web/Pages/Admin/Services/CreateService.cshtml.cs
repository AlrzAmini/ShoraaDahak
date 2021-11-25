using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoraaDahak.Core.Consts;
using ShoraaDahak.Core.Security;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.Services;

namespace ShoraaDahak.Web.Pages.Admin.Services
{
    [Authorize]
    [PermissionChecker(PerIds.AdminServices)]
    public class CreateServiceModel : PageModel
    {
        private readonly IServiceService _serviceService;

        public CreateServiceModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [BindProperty]
        public Service Service { get; set; } 

        public IActionResult OnGet()
        {
            var groups = _serviceService.GetGroupForManageServices();
            ViewData["Groups"] = new SelectList(groups,"Value","Text");

            var subGroups = _serviceService.GetSubGroupForManageServices(int.Parse(groups.First().Value));
            ViewData["SubGroups"] = new SelectList(subGroups, "Value", "Text");

            var writers = _serviceService.GetWriters();
            ViewData["Teachers"] = new SelectList(writers, "Value", "Text");

            var statuses = _serviceService.GetStatuses();
            ViewData["Statuses"] = new SelectList(statuses, "Value", "Text");

            return Page();
        }

        public IActionResult OnPost(IFormFile imgServiceUp,IFormFile videoUp)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _serviceService.AddService(Service, imgServiceUp, videoUp);

            return RedirectToPage("Index");
        }
    }
}
