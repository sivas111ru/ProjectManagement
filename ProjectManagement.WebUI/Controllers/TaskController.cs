using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ProjectManagement.Domain.Abstract;
using ProjectManagement.Domain.Concrete;
using ProjectManagement.Domain.Entities;
using ProjectManagement.WebUI.Models;


namespace ProjectManagement.WebUI.Controllers

{
    public class TaskController : Controller

    {
        private ITaskRepository taskRepository;

        public TaskController(ITaskRepository tData)
        {
            taskRepository = tData;
        }

        public ActionResult EditTask(int id)
        {
            var task = taskRepository.GetTaskById(id);

            if (task == null)
                return RedirectToAction("ViewProjects", "Home");

            var model = Mapper.Map<TaskViewModel>(task);
            model.UsersToTask = taskRepository.GetUsersAssignedToTask(id);
            model.StatusAll = Mapper.Map<List<TasksStatus>, List<SelectListItem>>(taskRepository.GetAllTasksStatuses());
            model.PriorityAll = Mapper.Map<List<TasksPriority>, List<SelectListItem>>(taskRepository.GetAllTaskPriorities());

            return View(model);
        }

        [HttpPost]
        public ActionResult EditTask(TaskViewModel model)
        {
            Task task = taskRepository.GetTaskById(model.Id);

            if (ModelState.IsValid && task != null)
            {
                Mapper.Map<TaskViewModel, Task>(model, task);

                taskRepository.UpdateTask(task);
            }

            return RedirectToAction("EditTask");
        }
    }
}