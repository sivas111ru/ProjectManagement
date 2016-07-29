using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Domain.Abstract
{
    public interface IDataRepository
    {
        IQueryable<Logs> Logs { get; }
        IQueryable<Projects> Projects { get; }
        IQueryable<sysdiagrams> sysdiagrams { get; }
        IQueryable<Tasks> Tasks { get; }
        IQueryable<TasksHistory> TasksHistory { get; }
        IQueryable<TasksHistoryTypes> TasksHistoryTypes { get; }
        IQueryable<TasksStatuses> TasksStatuses { get; }
        IQueryable<Users> Users { get; }
        IQueryable<UsersTasksMap> UsersTasksMap { get; }
    }
}
