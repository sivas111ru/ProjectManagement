using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Domain.Abstract;
using Task = ProjectManagement.Domain.Entities.Task;

namespace ProjectManagement.Domain.Concrete
{
    public class TaskRepository: BaseRepository, ITaskRepository
    {
        public IQueryable<Task> Tasks => dbContext.Tasks.AsQueryable();
        public Task GetTaskById(int id)
        {
            return Tasks.FirstOrDefault(t => t.id.Equals(id));
        }

        public bool AddTask(Task task)
        {
            if (task == null) return false;
        
            dbContext.Tasks.AddOrUpdate(task);
            dbContext.SaveChanges();
            return true;
        }

        public bool DeleteTask(Task task)
        {

            if (task == null ) return false;

            task.active = false;
            dbContext.Tasks.AddOrUpdate(task);
            dbContext.SaveChanges();

            return true;
        }

        public bool DeleteTask(int id)
        {
            var tsk = Tasks.FirstOrDefault(t => t.id.Equals(id));

            if (tsk == null) return false;

            tsk.active = false;
            dbContext.Tasks.AddOrUpdate(tsk);
            dbContext.SaveChanges();

            return true;
        }

        public bool UpdateTask(Task task)
        {
            if (task == null) return false;

            dbContext.Tasks.AddOrUpdate(task);
            dbContext.SaveChanges();
            return true;
        }

        public List<Task> GetTasksByProjectId(int id)
        {
            return Tasks.Where(t => t.fkProject.Equals(id) && t.active).ToList();
        }

        public List<Task> GetTasksByUserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
