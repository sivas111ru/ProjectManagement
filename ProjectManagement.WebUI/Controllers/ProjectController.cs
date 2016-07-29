using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Components.DictionaryAdapter;
using ProjectManagement.Domain.Abstract;
using ProjectManagement.Domain.Entities;
using ProjectManagement.WebUI.Models;

namespace ProjectManagement.WebUI.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private IDataRepository repository;

        public ProjectController(IDataRepository data)
        {
            repository = data;
        }


        public ViewResult ProjectPage(int id)
        {
            var result = (from p in repository.Projects where p.id == id   // to optimize
                           join t in repository.Tasks on p.id equals t.fkProject
                           join upm in repository.UsersTasksMap on t.id equals upm.fkTask
                           join u in repository.Users on upm.fkUser equals u.id
                           select u).ToList();
 



            return View(new ProjectPageViewModel() { UsersInvolved = result, Description = repository.Projects.Where(i => i.id == id).Select(d => d.description).FirstOrDefault() });

        }
    }
}