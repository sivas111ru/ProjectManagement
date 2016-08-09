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
            new User {name = "Test", email = "email", id = 10},
            new User {name = "Перескоков Владислав Сергеевич", email = "email", id = 11},
            new User {name = "Неперескоков Владислав Сергеевич", email = "email", id = 12},
            new User {name = "Фурс Владимир Владимирович", email = "email", id = 13},
            new User {name = "Сидоренко Василий Сергеевич", email = "email", id = 14},
            new User {name = "Нефурс Владимир Владимирович", email = "email", id = 15},
            new User {name = "Торбек Владимир Юрьевич", email = "email", id = 16},
            new User {name = "Неторбек Владимир Юрьевич", email = "email", id = 17},
            new User {name = "Второйнеторбек Владимир Юрьевич", email = "email", id = 18},
        };

        ITaskRepository taskRepository;

        public ApiController(ITaskRepository taskRepo)
        {
            taskRepository = taskRepo;
        }

        public JsonResult SearchUsers(string id)
        {
            String searchStr = id.ToLower();

            List<UserViewModel> u = Mapper.Map<List<User>, List<UserViewModel>>(testUsers.Where(x => x.name.ToLower().Contains(searchStr)).Take(5).ToList());
            
            return Json(u);
        }

        public JsonResult GetUsersOnTask(int id)
        {
            List<UserViewModel> u = Mapper.Map<List<User>, List<UserViewModel>>(taskRepository.GetUsersAssignedToTask(id));

            return Json(u);
        }
    }
}