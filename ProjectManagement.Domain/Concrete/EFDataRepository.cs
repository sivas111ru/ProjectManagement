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

        public IQueryable<Logs> Logs => context.Logs.AsQueryable() ;
        public IQueryable<Projects> Projects => context.Projects.AsQueryable();
        public IQueryable<sysdiagrams> sysdiagrams => context.sysdiagrams.AsQueryable();
        public IQueryable<Tasks> Tasks => context.Tasks.AsQueryable();
        public IQueryable<TasksHistory> TasksHistory => context.TasksHistory.AsQueryable();
        public IQueryable<TasksHistoryTypes> TasksHistoryTypes => context.TasksHistoryTypes.AsQueryable();
        public IQueryable<TasksStatuses> TasksStatuses => context.TasksStatuses.AsQueryable();
        public IQueryable<Users> Users => context.Users.AsQueryable();
        public IQueryable<UsersTasksMap> UsersTasksMap => context.UsersTasksMap.AsQueryable();
    }
}