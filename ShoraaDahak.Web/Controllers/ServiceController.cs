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

        public IActionResult Index(int pageNum = 1, string filterServiceName = "",
            string orderBy = "sTitle", List<int> selectedGroups = null)
        {
            ViewBag.selectedGroups = selectedGroups;
            ViewBag.orderBy = orderBy;
            ViewBag.ServicesGroups = _serviceService.GetAllServicesGroups();
            ViewBag.pageNum = pageNum;
            
            int totalPage = (int)Math.Ceiling((decimal)_serviceService.GetServices().Count() / 9);
            ViewBag.totalPage = totalPage;
            return View(_serviceService.GetServices(pageNum,filterServiceName,orderBy,selectedGroups,9));
        }
    }
}
