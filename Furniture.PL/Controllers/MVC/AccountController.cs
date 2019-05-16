using AutoMapper;
using Furniture.BLL;
using Furniture.PL.Models;
using Furniture.PL.Models.Authetification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Furniture.PL.Controllers.MVC
{
    public partial class AccountController : Controller
    {
        private UserService userService = null;
        public AccountController()
        {
            userService = new UserService();
        }
        /// <summary>
        /// Регистрация пользователя с ролью Admin or User
        /// </summary>
        /// <param name="password">пароль для Администратора</param>
        /// <returns></returns>
        /// <seealso cref="Register(RegisterViewModel)"/>
        [HttpGet]
        public virtual ActionResult Register(int? password = null)
        {
            int passwordForAdmin = 12;
            RegisterViewModel model = new RegisterViewModel();
            if (passwordForAdmin == password)
            {
                model.Role = "Admin";
            }
            else
            {
                model.Role = "User";
            }
            return View("Register", model);
        }
        /// <summary>
        /// Регистрация пользователя с ролью Admin or User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO user = new UserDTO(model.UserName, model.Email, model.Password, model.Role);
                bool ifRegistered;
                using (userService)
                {
                    ifRegistered = userService.CreateUser(user);
                }
                if (ifRegistered)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Такой пользователь уже существует");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Заполните поля");
            }
            return View("Register", model);
        }
        [HttpGet]
        public virtual ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool ifExist;
                // поиск пользователя в бд
                using (userService)
                {
                    ifExist = userService.FindUser(model.Email, model.Password);
                }
                if (ifExist)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Такого пользователя не существует");
                }
            }
            else
            {
                ModelState.AddModelError("", "Заполните поля");
            }

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}