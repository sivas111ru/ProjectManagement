using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Castle.Components.DictionaryAdapter;
using ProjectManagement.Domain.Abstract;
using ProjectManagement.Domain.Entities;
using ProjectManagement.WebUI.Models;

namespace ProjectManagement.WebUI.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private IProjectRepository ProjectRepository;
        private IUserRepository UserRepository;
        private ITaskRepository TaskRepository;

        public ProjectController(IProjectRepository data, IUserRepository udata, ITaskRepository trRepository)
        {
            ProjectRepository = data;
            UserRepository = udata;
            TaskRepository = trRepository;
        }


        public ViewResult ProjectPage(int id)
        {
            var project = ProjectRepository.GetProjectById(id);
            var usersInvolved = Mapper.Map<List<User>, List<UserViewModel>>(ProjectRepository.GetAllUsersByProjectId(id));
            var tasksInvolved = (from a in TaskRepository.UsersTasksMaps
                                 where a.active && a.Task.fkProject == id
                                 select new
                                 {
                                     a.Task,
                                     a.User
                                 }).ToList();


            {
            return View(new ProjectPageViewModel()
                UsersInvolved = usersInvolved,
                Description = project.description,
                TasksInvolved = tasksInvolved.Select(x => Tuple.Create(x.Task, x.User)).ToList()
            }
                );
        }

        public ViewResult ProjectUsersEdit(int id)
        {
            return View((from map in ProjectRepository.UserProjectMaps where map.accessLvl > 0 && map.fkProject == id && map.active
                         select new ProjectUsersEditViewModel
                         {
                             UserId = map.fkUser,
                             ProjectId = map.fkProject,
                             UserName = map.User.name,
                             ProjectName = map.Project.name,
                             AccessLvl = map.accessLvl.ToString()
                         }));
        }


        public ActionResult DeleteUserFromProject(int userId, int prjId)
        {
            ProjectRepository.DeleteUserFromProject(userId,prjId);

            return RedirectToAction("ProjectUsersEdit", new { id = prjId });
        }


        public ViewResult ProjectCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProjectCreate(Project model)
        {
            model.active = true;
            model.fkInitiator = UserRepository.GetUserByEmail(User.Identity.Name).id; // OMG
            model.createDate = DateTime.Now;
            ProjectRepository.CreateProject(model);

            return RedirectToAction("ProjectsView");
        }


        public ViewResult ProjectsView()
        {
            var projects = ProjectRepository.GetProjects();

            var model = Mapper.Map<List<Project>, List<ProjectsViewModel>>(projects);

            return View(model);
        }

        public ActionResult DeleteProject(int prjId)
        {
            ProjectRepository.DeleteProject(prjId);

            return RedirectToAction("ProjectsView");
        }
    }
}