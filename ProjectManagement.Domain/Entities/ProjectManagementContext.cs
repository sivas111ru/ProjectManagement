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

        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<TasksHistory> TasksHistory { get; set; }
        public virtual DbSet<TasksHistoryTypes> TasksHistoryTypes { get; set; }
        public virtual DbSet<TasksStatuses> TasksStatuses { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersTasksMap> UsersTasksMap { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logs>()
                .Property(e => e.message)
                .IsUnicode(false);

            modelBuilder.Entity<Projects>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Projects>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Projects>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Projects)
                .HasForeignKey(e => e.fkProject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tasks>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Tasks>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Tasks>()
                .HasMany(e => e.TasksHistory)
                .WithRequired(e => e.Tasks)
                .HasForeignKey(e => e.fkTask)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tasks>()
                .HasMany(e => e.UsersTasksMap)
                .WithRequired(e => e.Tasks)
                .HasForeignKey(e => e.fkTask)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TasksHistory>()
                .Property(e => e.message)
                .IsUnicode(false);

            modelBuilder.Entity<TasksHistoryTypes>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<TasksHistoryTypes>()
                .HasMany(e => e.TasksHistory)
                .WithRequired(e => e.TasksHistoryTypes)
                .HasForeignKey(e => e.fkTaskHistoryTypes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TasksStatuses>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<TasksStatuses>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.TasksStatuses)
                .HasForeignKey(e => e.status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Logs)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.fkUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Projects)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.fkInitiator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.TasksHistory)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.fkUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UsersTasksMap)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.fkUser)
                .WillCascadeOnDelete(false);
        }
    }
}
