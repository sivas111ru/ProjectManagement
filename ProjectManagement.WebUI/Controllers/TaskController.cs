using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagement.Domain.Abstract;
using ProjectManagement.Domain.Concrete;
using ProjectManagement.Domain.Entities;
using ProjectManagement.WebUI.Models;


namespace ProjectManagement.WebUI.Controllers

{
    public class TaskController : Controller

    {
        private IDataRepository repository;
        private ITaskRepository taskRepository;

        public TaskController(IDataRepository data, ITaskRepository tData)
        {
            repository = data;
            taskRepository = tData;
        }

        public ActionResult EditTask(int id)
        {
            var task = taskRepository.GetTaskById(id);

            if (task == null)
                return RedirectToAction("ViewProjects", "Home");

            var statuses = repository.TasksStatuses.Select(ts => new SelectListItem
            {
                Text = ts.name,
                Value = ts.id.ToString()
            }).ToList();

            var usersToTask = (from utm in repository.UsersTasksMap
                where utm.fkTask == id
                join user in repository.Users on utm.fkUser equals user.id
                select user.name).ToList();


            return View(new TaskViewModel
            {
                Id = task.id,
                Name = task.name,
                Description = task.description,
                Status = task.status,
                StartDate = task.startDate,
                EndDate = task.endDate,
                StatusAll = statuses,
                UsersToTask = usersToTask
            });
        }

        [HttpPost]
        public ActionResult EditTask(TaskViewModel model)
        {
            Task task = taskRepository.GetTaskById(model.Id);

            if (ModelState.IsValid && task != null)
            {
                task.name = model.Name;
                task.description = model.Description;
                task.status = model.Status;
                task.priority = model.Priority;
                task.startDate = model.StartDate;
                task.endDate = model.EndDate;

                taskRepository.UpdateTask(task);
            }

            return RedirectToAction("EditTask");
        }
    }
}