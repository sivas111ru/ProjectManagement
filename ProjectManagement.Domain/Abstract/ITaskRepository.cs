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
        Task GetTaskById(int id);
        bool AddTask(Task task);
        bool DeleteTask(Task task);
        bool DeleteTask(int id);
        bool UpdateTask(Task task);
        List<Task> GetTasksByProjectId(int id);
        List<Task> GetTasksByUserId(int id);
    }
}
