using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Domain.Abstract
{
    public interface IDataRepository
    {
        IQueryable<User> Users { get; }

        IQueryable<Project> Projects { get; }
    }
}
