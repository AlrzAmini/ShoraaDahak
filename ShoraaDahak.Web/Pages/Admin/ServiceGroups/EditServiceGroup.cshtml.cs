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
    public class EditServiceGroupModel : PageModel
    {
        private readonly IServiceService _serviceService;

        public EditServiceGroupModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [BindProperty]
        public ServiceGroup ServiceGroup { get; set; }

        public IActionResult OnGet(int id)
        {
            ServiceGroup = _serviceService.GetAllServicesGroupById(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _serviceService.UpdateServiceGroup(ServiceGroup);

            return RedirectToPage("Index");
        }
    }
}
