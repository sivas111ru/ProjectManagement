using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Domain.Concrete
{
    public class EFDbContext : DbContext // important!
    {
        public DbSet<Project> Projects { get; set; }

        public DbSet<Entities.Task> Tasks { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
