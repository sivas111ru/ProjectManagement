using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagement.Domain.Abstract;

namespace ProjectManagement.WebUI.Controllers
{
    // connection test
    [Authorize]
    public class TestController : Controller
    {
        private IDataRepository repository;

        public TestController(IDataRepository userRepository)
        {
            repository = userRepository;
        }

        public ViewResult Test()
        {
            return View(repository.Users);
        }

    }
}