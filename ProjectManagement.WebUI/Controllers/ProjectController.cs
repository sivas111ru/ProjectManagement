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
            var project = repository.GetProjectById(id);
            var usersInvolved = repository.GetAllUsersByProjectId(id);

            return View(new ProjectPageViewModel() {
                UsersInvolved = usersInvolved,
                Description = project.description}
            );
        }
    }
}