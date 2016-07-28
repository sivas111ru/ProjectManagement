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

            var result = repository.Projects.OrderByDescending(d => d.createDate)
                    .Take(5)
                    .Join(repository.Users, p => p.fkInitiator, u => u.id, (p, u) => new
                    {
                        id = p.id,
                        name = p.name,
                        initiator = u.name,
                        createDate = p.createDate
                    }).ToList();

            foreach (var project in result)
            {
                projectsToShow.Add(new ProjectsViewModel
                {
                    id = project.id,
                    name = project.name,
                    createDate = project.createDate,
                    Initiator = project.initiator
                });
            }
            return View(projectsToShow);
        }
    }
}