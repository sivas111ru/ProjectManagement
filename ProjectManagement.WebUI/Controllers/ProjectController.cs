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
        private IProjectRepository repository;

        public ProjectController(IProjectRepository data)
        {
            repository = data;
        }


        public ViewResult ProjectPage(int id)
        {
            return View(new ProjectPageViewModel() { UsersInvolved = repository.GetAllUsersByProjectId(id),
                                                     Description = repository.Projects.Where(i => i.id == id).Select(d => d.description).FirstOrDefault() });
        }
    }
}