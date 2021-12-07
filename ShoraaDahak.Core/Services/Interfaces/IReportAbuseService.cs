using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.DataLayer.Models.ReportAbuse;

namespace ShoraaDahak.Core.Services.Interfaces
{
    public interface IReportAbuseService
    {
        void AddReport(ReportAbuse abuse);

        ReportAbuse GetReportById(int reportId);

        void DeleteReportById(int reportId);

        List<ReportsInAdminViewModel> GetAllReports();

        void UpdateIsReadForReport(int reportId);

        List<ReportAbuse> GetReportsForSender(int senderId);
    }
}
