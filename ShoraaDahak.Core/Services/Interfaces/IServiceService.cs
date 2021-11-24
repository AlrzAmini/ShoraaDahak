using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        #endregion
    }
}
