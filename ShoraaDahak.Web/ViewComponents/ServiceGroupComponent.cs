using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoraaDahak.Core.Services.Interfaces;

namespace ShoraaDahak.Web.ViewComponents
{
    public class ServiceGroupComponent : ViewComponent
    {
        private readonly IServiceService _serviceService;

        public ServiceGroupComponent(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult) View("ServiceGroup",_serviceService.GetAllServicesGroups()));
        }
    }
}
