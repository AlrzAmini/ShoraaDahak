using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.Services;

namespace ShoraaDahak.Web.Pages.Admin.ServiceGroups
{
    public class CreateServiceGroupModel : PageModel
    {
        private readonly IServiceService _serviceService;

        public CreateServiceGroupModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [BindProperty]
        public ServiceGroup ServiceGroup { get; set; }

        public IActionResult OnGet(int? id)
        {
            ServiceGroup = new ServiceGroup()
            {
                ParrentId = id
            };
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _serviceService.AddServiceGroup(ServiceGroup);

            return RedirectToPage("Index");
        }
    }
}
