using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Components.DictionaryAdapter;
using ProjectManagement.Domain.Abstract;
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

        public ViewResult ViewProjects()
        {
            List<ProjectsViewModel> projectsToShow = new List<ProjectsViewModel>();

            foreach (var project in repository.Projects.OrderByDescending(d=>d.createDate).Take(5).ToList())
            {
                projectsToShow.Add(new ProjectsViewModel
                {
                    id = project.id,
                    name = project.name,
                    createDate = project.createDate,
                    Initiator = repository.Users.FirstOrDefault(u=>u.id == project.fkInitiator).name
                });
            }
            return View(projectsToShow);
        }
    }
}