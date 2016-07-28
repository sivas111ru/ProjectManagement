using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Domain.Abstract;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Domain.Concrete
{
    public class EFDataRepository: IDataRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<User> Users => context.Users;
        public IQueryable<Project> Projects => context.Projects;
    }
}
