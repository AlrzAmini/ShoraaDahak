using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoraaDahak.DataLayer.Models.Services;

namespace ShoraaDahak.Core.Services.Interfaces
{
    public interface IServiceService
    {
        #region Groups

        List<ServiceGroup> GetAllServicesGroups();

        #endregion
    }
}
