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

        public ViewResult EditTask(int id)
        {
            var task = taskRepository.GetTaskById(id);


            var statuses = repository.TasksStatuses.ToList().Select(ts => new SelectListItem
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
                Task = task,
                StatusAll = statuses,
                UsersToTask = usersToTask,
                SelectedStatus = task.status
            });
        }

        [HttpPost]
        public ActionResult EditTask(TaskViewModel model, string status)
        {
            Task task = taskRepository.GetTaskById(model.Task.id);

            if (ModelState.IsValid && task != null)
            {
                task.name = model.Task.name;
                task.description = model.Task.description;
                task.status = model.SelectedStatus;
                task.priority = model.Task.priority;
                task.startDate = model.Task.startDate;
                task.endDate = model.Task.endDate;

                taskRepository.UpdateTask(task);
            }


            return RedirectToAction("EditTask");
        }
    }
}