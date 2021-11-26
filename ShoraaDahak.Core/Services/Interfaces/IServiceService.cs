﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.DataLayer.Models.Services;

namespace ShoraaDahak.Core.Services.Interfaces
{
    public interface IServiceService
    {
        #region Groups

        List<ServiceGroup> GetAllServicesGroups();

        List<SelectListItem> GetGroupForManageServices();

        List<SelectListItem> GetSubGroupForManageServices(int groupId);

        #endregion

        #region Service

        List<SelectListItem> GetWriters();

        List<SelectListItem> GetStatuses();

        List<ShowServicesInAdminViewModel> GetServicesInAdmin();

        ServicesForAdminViewModel GetAllServices(int pageId = 1, string filterName = "");

        int AddService(Service service,IFormFile imgService,IFormFile videoService);

        Service GetServiceById(int id);

        void UpdateService(Service service, IFormFile imgService, IFormFile videoService);

        #endregion
    }
}
