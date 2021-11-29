﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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


        public IActionResult Index()
        {
            return View();
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
            int disId = _discussionService.AddDiscussion(discussion);

            return Redirect("/Discussion/ShowDiscussion/"+disId);
        }

        #endregion

        #region Show Discussion

        public IActionResult ShowDiscussion(int id) // id = Discussion Id
        {
            return View(_discussionService.ShowDiscussion(id));
        }

        #endregion
    }
}