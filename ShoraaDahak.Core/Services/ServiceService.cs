using System;
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
            return _context.ServiceGroups.Include(g=>g.ServiceGroups).ToList();
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
                imgResizer.Image_resize(imgPath, thumbPath, 400);
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
                Services = result.OrderBy(u => u.ServiceTitle).Skip(skip).Take(take).ToList()
            };

            return list;
        }

        public Service GetServiceById(int id)
        {
            return _context.Service.Find(id);
        }

        public void UpdateService(Service service, IFormFile imgService, IFormFile videoService)
        {
            service.ServiceUpdateDate = DateTime.Now;

            #region Add And Check Image & Video

            if (imgService != null && imgService.IsImage())
            {
                // if had image : Delete it
                if (service.ServiceImageName != "Defualt.webp")
                {
                    string imgDeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Service/image",
                        service.ServiceImageName);
                    if (File.Exists(imgDeletePath))
                    {
                        File.Delete(imgDeletePath);
                    }

                    string thumbDeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Service/thumb",
                        service.ServiceImageName);
                    if (File.Exists(thumbDeletePath))
                    {
                        File.Delete(thumbDeletePath);
                    }
                }
                service.ServiceImageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(imgService.FileName);
                string imgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Service/image", service.ServiceImageName);

                using (var stream = new FileStream(imgPath, FileMode.Create))
                {
                    imgService.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Service/thumb", service.ServiceImageName);
                imgResizer.Image_resize(imgPath, thumbPath, 400);
            }

            if (videoService != null)
            {
                // if had video : Delete it
                if (service.ServiceVideoName != null)
                {
                    string vidDeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Service/video",
                        service.ServiceVideoName);
                    if (File.Exists(vidDeletePath))
                    {
                        File.Delete(vidDeletePath);
                    }
                }
                service.ServiceVideoName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(videoService.FileName);
                string videoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Service/video", service.ServiceVideoName);

                using (var stream = new FileStream(videoPath, FileMode.Create))
                {
                    videoService.CopyTo(stream);
                }
            }

            #endregion

            _context.Service.Update(service);
            _context.SaveChanges();

        }

        public void DeleteService(int id)
        {
            Service service = GetServiceById(id);

            // Delete Image & Thumb
            if (service.ServiceImageName != null)
            {
                if (service.ServiceImageName != "Defualt.webp")
                {
                    string imgDeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Service/image",
                        service.ServiceImageName);
                    if (File.Exists(imgDeletePath))
                    {
                        File.Delete(imgDeletePath);
                    }

                    string thumbDeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Service/thumb",
                        service.ServiceImageName);
                    if (File.Exists(thumbDeletePath))
                    {
                        File.Delete(thumbDeletePath);
                    }
                }
            }

            // Delete Video
            if (service.ServiceVideoName != null)
            {
                string vidDeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Service/video",
                    service.ServiceVideoName);
                if (File.Exists(vidDeletePath))
                {
                    File.Delete(vidDeletePath);
                }
            }

            _context.Service.Remove(service);
            _context.SaveChanges();
        }

        public ServiceInAdminForDelete GetServiceForDelete(int id)
        {
            return _context.Service.Where(s => s.ServiceId == id)
                 .Select(s => new ServiceInAdminForDelete
                 {
                     ServiceId = s.ServiceId,
                     Budget = s.ServiceBudget,
                     Title = s.ServiceTitle
                 }).Single();
        }

        public List<ShowServiceInIndexViewModel> GetServices(int pageNum = 1, string filterServiceName = "",
            string orderBy = "sTitle", List<int> selectedGroups = null, int take = 0)
        {
            IQueryable<Service> result = _context.Service;

            if (take == 0)
            {
                take = Pagings.TakeServicesForShowInIndex;
            }

            if (!string.IsNullOrEmpty(filterServiceName))
            {
                result = result.Where(s => s.ServiceTitle.Contains(filterServiceName) || s.RelatedInstitutions.Contains(filterServiceName));
            }

            switch (orderBy)
            {
                case "sTitle":
                    {
                        result = result.OrderBy(s => s.ServiceTitle);

                        break;
                    }
                case "sDate":
                    {
                        result = result.OrderBy(s => s.ServiceStartDate);

                        break;
                    }
                case "upDate":
                    {
                        result = result.OrderBy(s => s.ServiceUpdateDate);

                        break;
                    }
            }

            if (selectedGroups != null && selectedGroups.Any())
            {
                foreach (int groupId in selectedGroups)
                {
                    result = result.Where(s => s.GroupId == groupId || s.SubGroup == groupId);
                }
            }

            //(int)Math.Ceiling((decimal)result.Count() / take)
            int skip = (pageNum - 1) * take;

            return result.Include(s => s.User)
                .Select(s => new ShowServiceInIndexViewModel()
                {
                    Title = s.ServiceTitle,
                    ServiceId = s.ServiceId,
                    ImageName = s.ServiceImageName,
                    Writer = s.User.Name
                }).Skip(skip).Take(take).ToList();
        }

        public Service GetCourseForShow(int id)
        {
            return _context.Service
                .Include(s=>s.User)
                .Include(s=>s.ServiceStatus)
                .Include(s=>s.ServiceGroup)
                .FirstOrDefault(s => s.ServiceId == id);
        }

        public void AddServiceGroup(ServiceGroup serviceGroup)
        {
            _context.ServiceGroups.Add(serviceGroup);
            _context.SaveChanges();
        }

        public void UpdateServiceGroup(ServiceGroup serviceGroup)
        {
            _context.ServiceGroups.Update(serviceGroup);
            _context.SaveChanges();
        }

        public ServiceGroup GetAllServicesGroupById(int id)
        {
            return _context.ServiceGroups.Find(id);
        }

        public void DeleteServiceGroup(ServiceGroup serviceGroup)
        {
            _context.ServiceGroups.Remove(serviceGroup);
            _context.SaveChanges();
        }
    }
}
