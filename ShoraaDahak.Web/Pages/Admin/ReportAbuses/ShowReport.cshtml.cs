using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.ReportAbuse;

namespace ShoraaDahak.Web.Pages.Admin.ReportAbuses
{
    public class ShowReportModel : PageModel
    {
        private readonly IReportAbuseService _reportAbuseService;

        public ShowReportModel(IReportAbuseService reportAbuseService)
        {
            _reportAbuseService = reportAbuseService;
        }

        [BindProperty]
        public ReportAbuse ReportAbuse { get; set; }

        public void OnGet(int id)
        {
            ReportAbuse = _reportAbuseService.GetReportById(id);
        }
    }
}
