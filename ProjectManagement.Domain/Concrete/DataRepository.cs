using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Domain.Abstract;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Domain.Concrete
{
    public class DataRepository : BaseRepository, IDataRepository
    {

        public IQueryable<Log> Logs => dbContext.Logs.AsQueryable() ;
    }
}