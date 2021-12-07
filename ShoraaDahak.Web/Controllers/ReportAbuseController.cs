using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ganss.XSS;
using Microsoft.AspNetCore.Authorization;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.ReportAbuse;

namespace ShoraaDahak.Web.Controllers
{
    public class ReportAbuseController : Controller
    {
        private readonly IReportAbuseService _reportAbuseService;

        public ReportAbuseController(IReportAbuseService reportAbuseService)
        {
            _reportAbuseService = reportAbuseService;
        }

        [Authorize]
        [Route("/SendReport")]
        public IActionResult SendReport()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Route("/SendReport")]
        public IActionResult SendReport(ReportAbuse report)
        {
            if (!ModelState.IsValid)
            {
                return View(report);
            }

            var sanitizer = new HtmlSanitizer();
            var sanitizedDescription = sanitizer.Sanitize(report.ReportDescription);
            report.ReportDescription = sanitizedDescription;

            report.CreateDate = DateTime.Now;
            report.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            _reportAbuseService.AddReport(report);

            return View("SeccessSendReport");
        }
    }
}
