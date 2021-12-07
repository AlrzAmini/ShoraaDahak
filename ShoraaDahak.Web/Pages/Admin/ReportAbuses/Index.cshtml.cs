using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.ReportAbuse;

namespace ShoraaDahak.Web.Pages.Admin.ReportAbuses
{
    public class IndexModel : PageModel
    {
        private readonly IReportAbuseService _reportAbuseService;

        public IndexModel(IReportAbuseService reportAbuseService)
        {
            _reportAbuseService = reportAbuseService;
        }

        public List<ReportsInAdminViewModel> Reports { get; set; }

        public IActionResult OnGet()
        {
            Reports = _reportAbuseService.GetAllReports();

            ViewData["TotalReports"] = Reports.Count;
            ViewData["TotalUnReadReports"] = Reports.Count(r=>r.IsRead == false);
            return Page();
        }

        public IActionResult OnGetRead(int id)
        {
            _reportAbuseService.UpdateIsReadForReport(id);

            return RedirectToPage("Index");
        }
    }
}
