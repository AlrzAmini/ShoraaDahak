using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoraaDahak.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using ShoraaDahak.Core.Services.Interfaces;

namespace ShoraaDahak.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceService _serviceService;

        public HomeController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            return View(_serviceService.GetServices());
        }

        [Route("/Error404")]
        public IActionResult Error404()
        {
            return View();
        }

        [Route("/AboutUs")]
        public IActionResult AboutUs()
        {
            return View();
        }

        [Route("/ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        #region External Login

        [Route("provider/{provider}")]
        public IActionResult GetProvider(string provider)
        {
            var redirectUrl = Url.RouteUrl("ExternalLogin", Request.Scheme); // full url

            return null;
        }

        [Route("external-login",Name = "ExternalLogin")]
        public IActionResult ExternalLogin()
        {
            return null;
        }

        #endregion



        [HttpPost]
        [Route("file-upload")]
        public IActionResult UploadImage(IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            if (upload.Length <= 0) return null;

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();

            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/MyImages",
                fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                upload.CopyTo(stream);

            }

            var url = $"{"/MyImages/"}{fileName}";


            return Json(new { uploaded = true, url });
        }

    }
}
