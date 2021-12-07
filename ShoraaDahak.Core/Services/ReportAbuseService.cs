using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Context;
using ShoraaDahak.DataLayer.Models.ReportAbuse;

namespace ShoraaDahak.Core.Services
{
    public class ReportAbuseService : IReportAbuseService
    {
        private readonly ShooraDahakContext _context;

        public ReportAbuseService(ShooraDahakContext context)
        {
            _context = context;
        }

        public void AddReport(ReportAbuse abuse)
        {
            _context.ReportAbuses.Add(abuse);
            _context.SaveChanges();
        }

        public void DeleteReportById(int reportId)
        {
            var report = GetReportById(reportId);

            _context.ReportAbuses.Remove(report);
            _context.SaveChanges();
        }

        public List<ReportsInAdminViewModel> GetAllReports()
        {
            return _context.ReportAbuses
                .Include(r => r.User)
                .Select(r => new ReportsInAdminViewModel()
                {
                    CreateDate = r.CreateDate,
                    Address = r.ReportAddress,
                    Subject = r.ReportSubject,
                    IsRead = r.IsRead,
                    SenderName = r.User.Name,
                    ReportId = r.ReportId
                }).ToList();
        }

        public ReportAbuse GetReportById(int reportId)
        {
            return _context.ReportAbuses
                .Include(r=>r.User)
                .SingleOrDefault(r => r.ReportId == reportId);
        }

        public List<ReportAbuse> GetReportsForSender(int senderId)
        {
            return _context.ReportAbuses
                .Include(r=>r.User)
                .Where(r => r.UserId == senderId)
                .ToList();
        }

        public void UpdateIsReadForReport(int reportId)
        {
            var report = GetReportById(reportId);

            report.IsRead = true;

            _context.ReportAbuses.Update(report);
            _context.SaveChanges();
        }
    }
}
