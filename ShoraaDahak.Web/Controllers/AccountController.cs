using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ShoraaDahak.Core.Convertors;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.Core.Generators;
using ShoraaDahak.Core.Security;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.User;

namespace ShoraaDahak.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #region Register

        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            // Check National Code
            if (_userService.IsNCodeExist(register.NCode))
            {
                ModelState.AddModelError("NCode", "کد ملی وارد شده تکراری است");
                return View(register);
            }

            // Check Email
            if (_userService.IsEmailExist(FixText.EmailFixer(register.Email)))
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده تکراری است");
                return View(register);
            }

            // Register User

            DataLayer.Models.User.User user = new User()
            {
                Email = FixText.EmailFixer(register.Email),
                Name = register.Name,
                NCode = register.NCode,
                PhoneNumber = register.PhoneNumber,
                BirthDate = register.BirthDate,
                Password = PasswordHasher.EncodePasswordMd5(register.Password),
                RegisterDate = DateTime.Now,
                ActivationCode = CodeGenerator.GenerateUniqCode(),
                IsActive = false
            };
            _userService.AddUser(user);

            //TODO: Send Email

            return View("RegisterConfirmed", user);
        }

        #endregion


        #region Login

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            DataLayer.Models.User.User user = _userService.IsUserValid(login);

            if (user != null)
            {
                if (!user.IsActive)
                {
                    ModelState.AddModelError("Password", "حساب کاربری شما فعال نشده است");
                    return View(login);
                }

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                    new Claim(ClaimTypes.Name,user.Name),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.MobilePhone,user.PhoneNumber)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                var properties = new AuthenticationProperties()
                {
                    IsPersistent = login.RememberMe
                };

                // command for login user
                HttpContext.SignInAsync(principal, properties);

                return Redirect("/");
            }

            ModelState.AddModelError("Password", "کاربری با این مشخصات ثبت نشده است");
            return View(login);

        }

        #endregion


        #region Active User

        public IActionResult ActiveUser(string id)
        {
            // if user was active or was null return = null
            ViewBag.IsActive = _userService.ActiveUser(id);

            return View();
        }

        #endregion

        #region Logout

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        #endregion

    }
}
