using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Domain.Abstract;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Domain.Concrete
{
    public class EFDataRepository : IDataRepository
    {
        private ProjectManagementContext context = new ProjectManagementContext();

        public IQueryable<Log> Logs => context.Logs.AsQueryable() ;
        public IQueryable<Project> Projects => context.Projects.AsQueryable();
        public IQueryable<sysdiagrams> sysdiagrams => context.sysdiagrams.AsQueryable();
        public IQueryable<Entities.Task> Tasks => context.Tasks.AsQueryable();
        public IQueryable<TaskHistory> TasksHistory => context.TasksHistory.AsQueryable();
        public IQueryable<TasksHistoryType> TasksHistoryTypes => context.TasksHistoryTypes.AsQueryable();
        public IQueryable<TasksStatus> TasksStatuses => context.TasksStatuses.AsQueryable();
        public IQueryable<User> Users => context.Users.AsQueryable();
        public IQueryable<UserTaskMap> UsersTasksMap => context.UsersTasksMap.AsQueryable();
    }
}