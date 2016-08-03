using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjectManagement.Domain.Abstract;
using ProjectManagement.Domain.Entities;
using ProjectManagement.WebUI.Infrastructure.Abstract;
using ProjectManagement.WebUI.Models;

namespace ProjectManagement.WebUI.Controllers
{   
    public class AccountController : Controller
    {
        private IAuthProvider authProvider;
        private IResetPass resetPass;
        private IDataRepository repository;
        private IUserRepository userRepository;

        public AccountController(IAuthProvider auth, IResetPass passR, IDataRepository data, IUserRepository userRepo)
        {
            authProvider = auth;
            resetPass = passR;
            repository = data;
            userRepository = userRepo;
        }
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.Email, model.Password))
                {
                    return Redirect(Url.Action("ViewProjects", "Home"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }

            return View();
        }

        public ViewResult UserPage()
        {
            var userEmail = User.Identity.Name;

            var user = userRepository.GetUserByEmail(userEmail);

            if (user == null)
                return View();

            UserPageViewModel model = new UserPageViewModel
            {
                Id = user.id,
                Email = user.email,
                Name = user.name,
                IsNotification = user.notification
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult UserPage(UserPageViewModel user)
        {
            var u = userRepository.GetUserById(user.Id);

            u.name = user.Name;
            u.email = user.Email;
            u.notification = user.IsNotification;

            userRepository.UpdateUser(u);

            return View(user);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

        public ViewResult ResetPass()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPass(ResetPassViewModel model)
        {
            if (resetPass.Reset(model.Email))
            {
                TempData["message"] = string.Format("Success. Check your email");
                return Redirect(Url.Action("Login", "Account"));
            }
            else
            {
                TempData["message"] = string.Format("Failed. This email is not registered");
                return View();
            }
            
        }

    }
}