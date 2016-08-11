using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using ProjectManagement.Domain.Abstract;
using ProjectManagement.Domain.Entities;
using Task = ProjectManagement.Domain.Entities.Task;

namespace ProjectManagement.Domain.Concrete
{
    public class TaskRepository: BaseRepository, ITaskRepository
    {
        public IQueryable<Task> Tasks => dbContext.Tasks.AsQueryable();
        public IQueryable<TasksHistory> TasksHistory => dbContext.TasksHistories.AsQueryable();
        public IQueryable<TasksHistoryType> TasksHistoryTypes => dbContext.TasksHistoryTypes.AsQueryable();
        public IQueryable<TasksStatus> TasksStatuses => dbContext.TasksStatuses.AsQueryable();
        public IQueryable<UsersTasksMap> UsersTasksMaps => dbContext.UsersTasksMaps.AsQueryable();
        public IQueryable<TasksPriority> TaskPriorities => dbContext.TasksPriorities.AsQueryable();

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
                dbContext.UsersTasksMaps.AddOrUpdate(new UsersTasksMap
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
                dbContext.UsersTasksMaps.Where(m => m.fkUser == id)
                    .Join(Tasks, map => map.fkTask, t => t.id, (map, t) => t)
                    .ToList();
        }

        public List<int> GetUsersIdbyTaskId(int id)
        {
            return dbContext.UsersTasksMaps.Where(m => m.fkTask == id).Select(i => i.fkUser).ToList();
        }

        public bool WriteHistory(int taskId, int userId, int statId, string msg)
        {
            try
            {
                var result = new TasksHistory
                {
                    fkTask = taskId,
                    fkUser = userId,
                    fkTaskHistoryTypes = statId,
                    message = msg,
                    dateTime = DateTime.Now
                };

                dbContext.TasksHistories.AddOrUpdate(result);
                dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public List<TasksHistory> GeTaskHistoryByTask(int id)
        {
            return TasksHistory.Where(t => t.fkTask.Equals(id)).ToList();
        }

        public List<TasksStatus> GetAllTasksStatuses()
        {
            return TasksStatuses.Select(a => a).ToList();
        }

        public List<TasksPriority> GetAllTaskPriorities()
        {
            return TaskPriorities.ToList();
        }

        public TasksHistoryType GeHistoryTypeById(int id)
        {
            return TasksHistoryTypes.FirstOrDefault(t => t.id.Equals(id));
        }

        public List<User> GetUsersAssignedToTask(int taskId)
        {
            return
                dbContext.UsersTasksMaps.Where(m => m.fkTask == taskId && m.active).Select(u=>u.User).ToList();
        }

        public void addUsersToTask(int taskId, List<int> usersToAdd)
        {
            List<User> users = dbContext.Users.Where(x => usersToAdd.Contains(x.id)).ToList();

            foreach (var user in users)
            {
                dbContext.UsersTasksMaps.Add(new UsersTasksMap
                {
                    active = true,
                    fkTask = taskId,
                    fkUser = user.id
                });
            }

            dbContext.SaveChanges();
        }

        public void removeUsersFromTask(int taskId, List<int> usersToRemove)
        {
            List<UsersTasksMap> users = dbContext.UsersTasksMaps.Where(x => x.fkTask.Equals(taskId) && x.active && usersToRemove.Contains(x.fkUser)).ToList();

            foreach (var u in users)
            {
                u.active = false;

                dbContext.UsersTasksMaps.AddOrUpdate(u);
            }

            dbContext.SaveChanges();
        }
    }
}
