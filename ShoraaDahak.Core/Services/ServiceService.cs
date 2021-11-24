using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public List<SelectListItem> GetGroupForManageServices()
        {
            return _context.ServiceGroups.Where(g => g.ParrentId == null)
                .Select(g => new SelectListItem()
                {
                    Value = g.GroupId.ToString(),
                    Text = g.GroupTitle
                }).ToList();
        }

        public List<SelectListItem> GetSubGroupForManageServices(int groupId)
        {
           return _context.ServiceGroups.Where(g => g.ParrentId == groupId)
                .Select(g => new SelectListItem()
                {
                    Value = g.GroupId.ToString(),
                    Text = g.GroupTitle
                }).ToList();
        }

        public List<SelectListItem> GetWriters()
        {
            return _context.UserRoles.Where(u => u.RoleId == 9)
                .Include(u => u.User)
                .Select(u => new SelectListItem()
                {
                    Value = u.UserId.ToString(),
                    Text = u.User.Name
                }).ToList();
        }
    }
}
