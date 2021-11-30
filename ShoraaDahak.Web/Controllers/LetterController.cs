using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.Letter;

namespace ShoraaDahak.Web.Controllers
{
    public class LetterController : Controller
    {
        private readonly ILetterService _letterService;

        public LetterController(ILetterService letterService)
        {
            _letterService = letterService;
        }

        #region Send Letter

        [Authorize]
        [Route("SendLetter")]
        public IActionResult SendLetter()
        {
            var leterTos = _letterService.GetLetterTosForSendLetter();
            ViewBag.LetterTos = new SelectList(leterTos, "Value", "Text");
            return View();
        }

        [Authorize]
        [HttpPost]
        [Route("SendLetter")]
        public IActionResult SendLetter(Letter letter, IFormFile letterFileUp)
        {
            if (!ModelState.IsValid)
            {
                return View(letter);
            }

            letter.SenderId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            _letterService.AddLetter(letter, letterFileUp);

            return View("SendSuccess", letter);
        }

        #endregion

        #region Success Send


        #endregion
    }
}
