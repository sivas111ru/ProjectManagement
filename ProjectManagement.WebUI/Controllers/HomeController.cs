using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ProjectManagement.Domain.Abstract;
using ProjectManagement.Domain.Entities;
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
            var projects = repository.GetLastNProjects(5);

            var model = Mapper.Map<List<Project>, List<ProjectsViewModel>>(projects);

            return View(model);
        }
    }
}