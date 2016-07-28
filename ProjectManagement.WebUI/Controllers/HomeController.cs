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
        private IDataRepository repository;

        public HomeController(IDataRepository data)
        {
            repository = data;
        }

        public ViewResult ViewProjects()
        {
            return View((from a in repository.Projects.OrderByDescending(d => d.createDate).Take(5)
                join b in repository.Users on a.fkInitiator equals b.id
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