﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Domain.Entities;
using Task = ProjectManagement.Domain.Entities.Task;

namespace ProjectManagement.Domain.Abstract
{
    public interface IDataRepository
    {
        IQueryable<Log> Logs { get; }
        IQueryable<Project> Projects { get; }
        IQueryable<sysdiagrams> sysdiagrams { get; }
        IQueryable<Entities.Task> Tasks { get; }
        IQueryable<TaskHistory> TasksHistory { get; }
        IQueryable<TasksHistoryType> TasksHistoryTypes { get; }
        IQueryable<TasksStatuses> TasksStatuses { get; }
        IQueryable<User> Users { get; }
        IQueryable<UserTaskMap> UsersTasksMap { get; }

        void AddOrUpdateTask(Task task);
    }
}
