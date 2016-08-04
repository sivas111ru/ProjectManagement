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
        private ProjectManagementEntities _dbContext; 
        protected ProjectManagementEntities dbContext
        {
            get
            {
                if (_dbContext == null) _dbContext = new ProjectManagementEntities();
                return _dbContext;
            }
        }
    
    }
}
