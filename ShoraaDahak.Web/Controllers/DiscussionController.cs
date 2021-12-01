using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ganss.XSS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.Discussion;

namespace ShoraaDahak.Web.Controllers
{
    public class DiscussionController : Controller
    {
        private readonly IDiscussionService _discussionService;

        public DiscussionController(IDiscussionService discussionService)
        {
            _discussionService = discussionService;
        }

        #region Create Discussion

        [Authorize] 
        public IActionResult CreateDiscussion(int id) // id = Service Id 
        {
            Discussion discussion = new Discussion()
            {
                ServiceId = id
            };

            var impLevels = _discussionService.GetImpLevels();
            ViewBag.ImpLevels = new SelectList(impLevels, "Value", "Text");

            return View(discussion);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateDiscussion(Discussion discussion)
        {
            if (!ModelState.IsValid)
            {
                return View(discussion);
            }

            discussion.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var sanitizer = new HtmlSanitizer();
            var sanitizedBody = sanitizer.Sanitize(discussion.DiscussionBody);
            discussion.DiscussionBody = sanitizedBody;
            int disId = _discussionService.AddDiscussion(discussion);

            return Redirect("/Discussion/ShowDiscussion/"+disId);
        }

        #endregion

        #region Show Discussion

        [Authorize]
        public IActionResult ShowDiscussion(int id) // id = Discussion Id
        {
            return View(_discussionService.ShowDiscussion(id));
        }

        #endregion

        #region Show Discussion list

        [Authorize]
        public IActionResult ShowDiscussionList(int id) // id = Service Id
        {
            return View(_discussionService.GetDiscussionsByServiceId(id));
        }

        #endregion

        #region Create Answer

        public IActionResult CreateAnswer(int id,string answerBody) // id = discussion id
        {
            if (!string.IsNullOrEmpty(answerBody))
            {
                var sanitizer = new HtmlSanitizer();
                answerBody = sanitizer.Sanitize(answerBody);

                Answer answer = new Answer()
                {
                    AnswerBody = answerBody,
                    UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString()),
                    DiscussionId = id,
                    CreateDate = DateTime.Now
                };

                _discussionService.AddAnswer(answer);
            }

            return RedirectToAction("ShowDiscussion",new{id=id});
        }

        #endregion
    }
}
