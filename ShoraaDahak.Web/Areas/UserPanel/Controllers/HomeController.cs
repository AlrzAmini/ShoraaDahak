using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.Core.Services.Interfaces;

namespace ShoraaDahak.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILetterService _letterService;

        public HomeController(IUserService userService, ILetterService letterService)
        {
            _userService = userService;
            _letterService = letterService;
        }

        public IActionResult Index()
        {
            return View(_userService.GetUserInformation(User.FindFirstValue(ClaimTypes.SerialNumber)));
        }


        #region Edit Information

        [Route("UserPanel/EditInfo")]
        public IActionResult EditInfo()
        {
            return View(_userService.GetUserInfoForEdit(User.FindFirstValue(ClaimTypes.Email)));
        }

        [HttpPost]
        [Route("UserPanel/EditInfo")]
        public IActionResult EditInfo(EditUserInfoViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }

            if (_userService.IsNCodeExist(edit.NCode) && edit.NCode != User.FindFirstValue(ClaimTypes.SerialNumber))
            {
                ModelState.AddModelError("NCode", "کد ملی وارد شده تکراری است");
                return View(edit);
            }


            _userService.EditUserInfo(User.FindFirstValue(ClaimTypes.Email),edit);
            ViewBag.IsSuccess = true;

            return View(_userService.GetUserInfoForEdit(User.FindFirstValue(ClaimTypes.Email)));

        }

        #endregion

        #region Change Password

        [Route("UserPanel/ChangePassword")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Route("UserPanel/ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordViewModel change)
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            if (!ModelState.IsValid)
            {
                return View(change);
            }

            if (!_userService.CompareOldPassword(email,change.OldPassword))
            {
                ModelState.AddModelError("OldPassword","رمز عبور فعلی صحیح نمی باشد");
                return View(change);
            }

            _userService.ChangePassword(email,change.Password);
            ViewBag.IsSuccess = true;

            return View();
        }

        #endregion

        #region Letters

        [Authorize]
        [Route("UserPanel/Letters")]
        public IActionResult Letters()
        {
            return View(_letterService.GetLettersForSender(int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }

        #endregion

        #region letter Answer

        [Authorize]
        [Route("UserPanel/LetterAnswers")]
        public IActionResult LetterAnswers()
        {
            int recieverId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(_letterService.GetLetterAnswersForLetterSender(recieverId));
        }

        #endregion
    }
}
