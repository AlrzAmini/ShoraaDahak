using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoraaDahak.Core.Services.Interfaces;

namespace ShoraaDahak.Web.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index(int pageNum = 1, string search = "",
            string orderBy = "sTitle", List<int> selectedGroups = null)
        {
            ViewBag.selectedGroups = selectedGroups;
            ViewBag.orderBy = orderBy;
            ViewBag.ServicesGroups = _serviceService.GetAllServicesGroups();
            ViewBag.pageNum = pageNum;

            int totalPage = (int)Math.Ceiling((decimal)_serviceService.GetServices().Count() / 9);
            ViewBag.totalPage = totalPage;

            return View(_serviceService.GetServices(pageNum, search, orderBy, selectedGroups, 9));
        }


        [Route("ShowService/{id}")]
        public IActionResult ShowService(int id)
        {
            var service = _serviceService.GetCourseForShow(id);

            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }
    }
}
