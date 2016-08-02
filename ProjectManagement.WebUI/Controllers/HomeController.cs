using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagement.Domain.Abstract;
using ProjectManagement.WebUI.Models;

namespace ProjectManagement.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IProjectRepository repository;
        private IUserRepository userRepository;

        public HomeController(IProjectRepository data, IUserRepository userRepo)
        {
            repository = data;

            userRepository = userRepo;
        }

        public ViewResult ViewProjects()
        {
            var result = repository.GetLastNProjects(5);

            return View((from a in result
                         join b in userRepository.Users on a.fkInitiator equals b.id
                select new ProjectsViewModel
                {
                    id = a.id,
                    name = a.name,
                    createDate = a.createDate,
                    Initiator = b.name
                }
                ));
        }
    }
}