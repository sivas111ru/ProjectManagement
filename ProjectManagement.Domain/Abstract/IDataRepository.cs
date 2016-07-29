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
        DbSet<Logs> Logs { get; set; }
        DbSet<Projects> Projects { get; set; }
        DbSet<sysdiagrams> sysdiagrams { get; set; }
        DbSet<Tasks> Tasks { get; set; }
        DbSet<TasksHistory> TasksHistory { get; set; }
        DbSet<TasksHistoryTypes> TasksHistoryTypes { get; set; }
        DbSet<TasksStatuses> TasksStatuses { get; set; }
        DbSet<Users> Users { get; set; }
        DbSet<UsersTasksMap> UsersTasksMap { get; set; }
    }
}
