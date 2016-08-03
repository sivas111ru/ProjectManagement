using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Domain.Abstract
{
    public interface ITaskRepository
    {
        IQueryable<Task> Tasks { get; }
        IQueryable<TaskHistory> TasksHistory { get; }
        IQueryable<TasksHistoryType> TasksHistoryTypes { get; }
        IQueryable<TasksStatuses> TasksStatuses { get; }

        // Task
        Task GetTaskById(int id);
        bool AddTask(Task task);
        bool DeleteTask(Task task);
        bool DeleteTask(int id);
        bool UpdateTask(Task task);
        List<Task> GetTasksByProjectId(int id);

        //TaskHistory
        bool WriteHistory(int taskId, int userId, int statusTypeId, string msg);
        List<TaskHistory> GeTaskHistoryByTask(int id);

        //TaskStatuses
        List<TasksStatuses> GetAllTasksStatuses();

        //TaskHistoryTypes
        TasksHistoryType GeHistoryTypeById(int id);

        //UsersTasksMap
        List<Task> GetTasksByUserId(int id);
        bool AddUserTaskMap(int usrId, int tskId);
        List<Task> GetAllTaskByUserId(int id);
        List<int> GetUsersIdbyTaskId(int id);

    }
}
