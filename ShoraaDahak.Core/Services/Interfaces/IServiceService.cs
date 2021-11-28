using System;
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

        int AddService(Service service, IFormFile imgService, IFormFile videoService);

        Service GetServiceById(int id);

        void UpdateService(Service service, IFormFile imgService, IFormFile videoService);

        void DeleteService(int id);

        ServiceInAdminForDelete GetServiceForDelete(int id);

        List<ShowServiceInIndexViewModel> GetServices(int pageNum = 1, string filterServiceName = "", string orderBy = "sDate", List<int> selectedGroups = null, int take = 0);

        Service GetCourseForShow(int id);

        #endregion
    }
}
