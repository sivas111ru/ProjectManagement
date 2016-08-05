using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
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

        public ViewResult UserPage(int? id)
        {
            User user;

            if (id.HasValue)
            {
                int userId = id.Value;
                user = userRepository.GetUserById(userId);
            }
            else
            {
                var userEmail = User.Identity.Name;
                user = userRepository.GetUserByEmail(userEmail);
            }

            if (user == null)
                return View();

            UserPageViewModel model = Mapper.Map<UserPageViewModel>(user);
            model.Tasks = Mapper.Map<List<Task>, List<TaskViewModel>>(userRepository.GetuserTasks(user.id));

            return View(model);
        }


        public ActionResult Edit()
        {
            var userEmail = User.Identity.Name;
            User user = userRepository.GetUserByEmail(userEmail);

            if ( user == null )
                return RedirectToAction("ViewProjects", "Home");

            UserPageViewModel model = Mapper.Map<UserPageViewModel>(user);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserPageViewModel user)
        {
            var u = userRepository.GetUserById(user.Id);

            Mapper.Map<UserPageViewModel, User>(user, u);

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