﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Domain.Abstract;
using ProjectManagement.Domain.Entities;
using Task = ProjectManagement.Domain.Entities.Task;

namespace ProjectManagement.Domain.Concrete
{
    public class TaskRepository: BaseRepository, ITaskRepository
    {
        public IQueryable<Task> Tasks => dbContext.Tasks.AsQueryable();
        public IQueryable<TaskHistory> TasksHistory => dbContext.TasksHistory.AsQueryable();
        public IQueryable<TasksHistoryType> TasksHistoryTypes => dbContext.TasksHistoryTypes.AsQueryable();
        public IQueryable<TasksStatuses> TasksStatuses => dbContext.TasksStatuses.AsQueryable();

        public Task GetTaskById(int id)
        {
            return Tasks.FirstOrDefault(t => t.id.Equals(id));
        }

        public bool AddTask(Task task)
        {
            if (task == null) return false;
        
            dbContext.Tasks.AddOrUpdate(task);
            dbContext.SaveChanges();
            return true;
        }

        public bool DeleteTask(Task task)
        {

            if (task == null ) return false;

            task.active = false;
            dbContext.Tasks.AddOrUpdate(task);
            dbContext.SaveChanges();

            return true;
        }

        public bool DeleteTask(int id)
        {
            var tsk = Tasks.FirstOrDefault(t => t.id.Equals(id));

            if (tsk == null) return false;

            tsk.active = false;
            dbContext.Tasks.AddOrUpdate(tsk);
            dbContext.SaveChanges();

            return true;
        }

        public bool UpdateTask(Task task)
        {
            if (task == null) return false;

            dbContext.Tasks.AddOrUpdate(task);
            dbContext.SaveChanges();
            return true;
        }

        public List<Task> GetTasksByProjectId(int id)
        {
            return Tasks.Where(t => t.fkProject.Equals(id) && t.active).ToList();
        }

        public List<Task> GetTasksByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public bool AddUserTaskMap(int usrId, int tskId)
        {
            try
            {
                dbContext.UsersTasksMap.AddOrUpdate(new UserTaskMap
                {
                    active = true,
                    fkUser = usrId,
                    fkTask = tskId,
                });

                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<Task> GetAllTaskByUserId(int id)
        {
            return
                dbContext.UsersTasksMap.Where(m => m.fkUser == id)
                    .Join(Tasks, map => map.fkTask, t => t.id, (map, t) => t)
                    .ToList();
        }

        public List<int> GetUsersIdbyTaskId(int id)
        {
            return dbContext.UsersTasksMap.Where(m => m.fkTask == id).Select(i => i.fkUser).ToList();
        }

        public bool WriteHistory(int taskId, int userId, int statId, string msg)
        {
            try
            {
                var result = new TaskHistory
                {
                    fkTask = taskId,
                    fkUser = userId,
                    fkTaskHistoryTypes = statId,
                    message = msg,
                    dateTime = DateTime.Now
                };

                dbContext.TasksHistory.AddOrUpdate(result);
                dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public List<TaskHistory> GeTaskHistoryByTask(int id)
        {
            return TasksHistory.Where(t => t.fkTask.Equals(id)).ToList();
        }

        public List<TasksStatuses> GetAllTasksStatuses()
        {
            return TasksStatuses.Select(a => a).ToList();
        }

        public TasksHistoryType GeHistoryTypeById(int id)
        {
            return TasksHistoryTypes.FirstOrDefault(t => t.id.Equals(id));
        }

        public List<User> GetUsersAssignedToTask(int taskId)
        {
            return
                dbContext.UsersTasksMap.Where(m => m.fkTask == taskId)
                    .Join(dbContext.Users, map => map.fkUser, u => u.id, (map, u) => u)
                    .ToList();
        }
    }
}
