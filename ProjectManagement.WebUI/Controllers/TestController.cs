using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagement.Domain.Abstract;

namespace ProjectManagement.WebUI.Controllers
{
    // connection test
    public class TestController : Controller
    {
        private IUserRepository repository;

        public TestController(IUserRepository userRepository)
        {
            repository = userRepository;
        }

        public ViewResult Test()
        {
            return View(repository.Users);
        }

    }
}