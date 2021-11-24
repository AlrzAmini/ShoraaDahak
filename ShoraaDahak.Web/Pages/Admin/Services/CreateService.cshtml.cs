using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.Services;

namespace ShoraaDahak.Web.Pages.Admin.Services
{
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

            return Page();
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
