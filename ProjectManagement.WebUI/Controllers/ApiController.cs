using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using AutoMapper;
using Ninject;
using ProjectManagement.Domain.Abstract;
using ProjectManagement.Domain.Entities;
using ProjectManagement.WebUI.Models;

namespace ProjectManagement.WebUI.Controllers
{
    public class ApiController : Controller
    {
        List<User> testUsers = new List<User>
        {
            new User {name = "Test", email = "email", id = 1},
            new User {name = "Vlad", email = "email", id = 1},
            new User {name = "Vladislav", email = "email", id = 1},
            new User {name = "Vladimir", email = "email", id = 1},
            new User {name = "Vladimir2", email = "email", id = 1},

        };

        ITaskRepository taskRepository;

        public ApiController(ITaskRepository taskRepo)
        {
            taskRepository = taskRepo;
        }

        public JsonResult SearchUsers(string id)
        {
            List<UserViewModel> u = Mapper.Map<List<User>, List<UserViewModel>>(testUsers.Where(x => x.name.Contains(id)).ToList());
            
            return Json(u);
        }

        public JsonResult GetUsersOnTask(int id)
        {
            List<UserViewModel> u = Mapper.Map<List<User>, List<UserViewModel>>(taskRepository.GetUsersAssignedToTask(id));

            return Json(u);
        }
    }
}