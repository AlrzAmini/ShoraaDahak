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
    public class EditServiceModel : PageModel
    {
        private readonly IServiceService _serviceService;

        public EditServiceModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [BindProperty]
        public Service Service { get; set; }

        public IActionResult OnGet(int id)
        {
            Service = _serviceService.GetServiceById(id);

            var groups = _serviceService.GetGroupForManageServices();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text",Service.GroupId);

            var subGroups = _serviceService.GetSubGroupForManageServices(Service.GroupId);
            ViewData["SubGroups"] = new SelectList(subGroups, "Value", "Text",Service.SubGroup??0);

            var writers = _serviceService.GetWriters();
            ViewData["Teachers"] = new SelectList(writers, "Value", "Text",Service.WriterId);

            var statuses = _serviceService.GetStatuses();
            ViewData["Statuses"] = new SelectList(statuses, "Value", "Text",Service.StatusId);

            return Page();
        }

        public IActionResult OnPost(IFormFile imgServiceUp, IFormFile videoUp)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _serviceService.UpdateService(Service,imgServiceUp,videoUp);

            return RedirectToPage("Index");
        }
    }
}
