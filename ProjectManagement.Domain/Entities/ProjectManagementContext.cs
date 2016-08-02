using ProjectManagement.Domain.Abstract;

namespace ProjectManagement.Domain.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectManagementContext : DbContext
    {
        public ProjectManagementContext()
            : base("name=ProjectManagementContext")
        {
        }

        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskHistory> TasksHistory { get; set; }
        public virtual DbSet<TasksHistoryType> TasksHistoryTypes { get; set; }
        public virtual DbSet<TasksStatus> TasksStatuses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserTaskMap> UsersTasksMap { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>()
                .Property(e => e.message)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Projects)
                .HasForeignKey(e => e.fkProject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .HasMany(e => e.TasksHistory)
                .WithRequired(e => e.Tasks)
                .HasForeignKey(e => e.fkTask)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
                .HasMany(e => e.UsersTasksMap)
                .WithRequired(e => e.Tasks)
                .HasForeignKey(e => e.fkTask)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaskHistory>()
                .Property(e => e.message)
                .IsUnicode(false);

            modelBuilder.Entity<TasksHistoryType>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<TasksHistoryType>()
                .HasMany(e => e.TasksHistory)
                .WithRequired(e => e.TasksHistoryTypes)
                .HasForeignKey(e => e.fkTaskHistoryTypes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TasksStatus>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<TasksStatus>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.TasksStatuses)
                .HasForeignKey(e => e.status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Logs)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.fkUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Projects)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.fkInitiator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TasksHistory)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.fkUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UsersTasksMap)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.fkUser)
                .WillCascadeOnDelete(false);
        }
    }
}
