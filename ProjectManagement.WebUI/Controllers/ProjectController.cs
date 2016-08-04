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

        public ViewResult ProjectUsersEdit(int id)
        {
            return View((from map in repository.UserProjectMaps where map.accessLvl > 0 && map.fkProject == id
                         select new ProjectUsersEditViewModel
                         {
                             Id = map.id,
                             UserName = map.User.name,
                             ProjectName = map.Project.name,
                             AccessLvl = map.accessLvl.ToString()
                         }));
        }
    }
}