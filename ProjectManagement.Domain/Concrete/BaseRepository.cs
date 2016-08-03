using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Domain.Concrete
{
    public abstract class BaseRepository
    {
        private ProjectManagementContext _dbContext; 
        protected ProjectManagementContext dbContext
        {
            get
            {
                if (_dbContext == null) _dbContext = new ProjectManagementContext();
                return _dbContext;
            }
        }
    
    }
}
