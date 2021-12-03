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
        private readonly IBlogService _blogService;

        public HomeAdminController(IServiceService serviceService, IBlogService blogService)
        {
            _serviceService = serviceService;
            _blogService = blogService;
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

        public IActionResult GetSubCats(int id) // id = category Id
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید",Value = ""}
            };

            list.AddRange(_blogService.GetSubCats(id));

            return Json(new SelectList(list, "Value", "Text"));
        }
    }
}
