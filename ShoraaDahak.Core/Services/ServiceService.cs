using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Context;
using ShoraaDahak.DataLayer.Models.Services;

namespace ShoraaDahak.Core.Services
{
    public class ServiceService : IServiceService
    {
        private readonly ShooraDahakContext _context;

        public ServiceService(ShooraDahakContext context)
        {
            _context = context;
        }
        public List<ServiceGroup> GetAllServicesGroups()
        {
            return _context.ServiceGroups.ToList();
        }
    }
}
