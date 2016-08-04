﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManagement.Domain.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProjectManagementEntities : DbContext
    {
        public ProjectManagementEntities()
            : base("name=ProjectManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TasksHistory> TasksHistories { get; set; }
        public virtual DbSet<TasksHistoryType> TasksHistoryTypes { get; set; }
        public virtual DbSet<TasksPriority> TasksPriorities { get; set; }
        public virtual DbSet<TasksStatus> TasksStatuses { get; set; }
        public virtual DbSet<UserProjectMap> UserProjectMaps { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersTasksMap> UsersTasksMaps { get; set; }
    }
}