﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoraaDahak.Core.Consts;
using ShoraaDahak.Core.Convertors;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.Core.Generators;
using ShoraaDahak.Core.Security;
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

        public List<SelectListItem> GetStatuses()
        {
            return _context.ServiceStatus
                .Select(s => new SelectListItem()
                {
                    Value = s.StatusId.ToString(),
                    Text = s.StatusTitle
                }).ToList();
        }

        public int AddService(Service service, IFormFile imgService, IFormFile videoService)
        {
            #region Add And Check Image & Video

            service.ServiceImageName = "Defualt.webp";
            if (imgService != null && imgService.IsImage())
            {
                service.ServiceImageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(imgService.FileName);
                string imgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Service/image", service.ServiceImageName);

                using (var stream = new FileStream(imgPath, FileMode.Create))
                {
                    imgService.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Service/thumb", service.ServiceImageName);
                imgResizer.Image_resize(imgPath,thumbPath,120);
            }

            if (videoService != null)
            {
                service.ServiceVideoName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(videoService.FileName);
                string videoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Service/video", service.ServiceVideoName);

                using (var stream = new FileStream(videoPath, FileMode.Create))
                {
                    videoService.CopyTo(stream);
                }
            }

            #endregion

            _context.Service.Add(service);
            _context.SaveChanges();

            return service.ServiceId;
        }

        public List<ShowServicesInAdminViewModel> GetServicesInAdmin()
        {
            return _context.Service.Select(s => new ShowServicesInAdminViewModel()
            {
                ServiceTitle = s.ServiceTitle,
                ServiceBudget = s.ServiceBudget,
                ServiceStartDate = s.ServiceStartDate,
                ServiceId = s.ServiceId
            }).OrderBy(s => s.ServiceStartDate).ToList();
        }

        public ServicesForAdminViewModel GetAllServices(int pageId = 1, string filterServiceTitle = "")
        {
            IQueryable<ShowServicesInAdminViewModel> result = _context.Service.Select(s => new ShowServicesInAdminViewModel()
            {
                ServiceTitle = s.ServiceTitle,
                ServiceBudget = s.ServiceBudget,
                ServiceStartDate = s.ServiceStartDate,
                ServiceId = s.ServiceId
            });

            if (!string.IsNullOrEmpty(filterServiceTitle))
            {
                result = result.Where(u => u.ServiceTitle.Contains(filterServiceTitle));
            }

            int take = Pagings.TakeUserInAdmin;
            int skip = (pageId - 1) * take;

            ServicesForAdminViewModel list = new ServicesForAdminViewModel()
            {
                CurrentPage = pageId,
                TotalPages = (int)Math.Ceiling((decimal)result.Count() / take),
                Services = result.OrderBy(u => u.ServiceStartDate).Skip(skip).Take(take).ToList()
            };

            return list;
        }
    }
}
