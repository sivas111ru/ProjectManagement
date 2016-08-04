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
        IQueryable<TasksHistory> TasksHistory { get; }
        IQueryable<TasksHistoryType> TasksHistoryTypes { get; }
        IQueryable<TasksStatus> TasksStatuses { get; }

        // Task
        Task GetTaskById(int id);
        bool AddTask(Task task);
        bool DeleteTask(Task task);
        bool DeleteTask(int id);
        bool UpdateTask(Task task);
        List<Task> GetTasksByProjectId(int id);

        //TaskHistory
        bool WriteHistory(int taskId, int userId, int statusTypeId, string msg);
        List<TasksHistory> GeTaskHistoryByTask(int id);

        //TaskStatuses
        List<TasksStatus> GetAllTasksStatuses();

        //TaskPriorities
        List<TasksPriority> GetAllTaskPriorities();

            //TaskHistoryTypes
        TasksHistoryType GeHistoryTypeById(int id);

        //UsersTasksMap
        List<Task> GetTasksByUserId(int id);
        bool AddUserTaskMap(int usrId, int tskId);
        List<Task> GetAllTaskByUserId(int id);
        List<int> GetUsersIdbyTaskId(int id);
        List<User> GetUsersAssignedToTask(int taskId);

    }
}
