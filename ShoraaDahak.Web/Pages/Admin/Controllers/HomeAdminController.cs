using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoraaDahak.Core.Services.Interfaces;

namespace ShoraaDahak.Web.Pages.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        private readonly IServiceService _serviceService;

        public HomeAdminController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult GetSubGroups(int id) // id = groupId
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید",Value = ""}
            };
            list.AddRange(_serviceService.GetSubGroupForManageServices(id));
            return Json(new SelectList(list, "Value", "Text"));
        }
    }
}
