using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Domain.Abstract;
using Task = ProjectManagement.Domain.Entities.Task;

namespace ProjectManagement.Domain.Concrete
{
    public class TaskRepository: BaseRepository, ITaskRepository
    {
        public IQueryable<Task> Tasks { get; }
        public Task GetTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public bool AddTask(Task task)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTask(Task task)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTask(Task task)
        {
            throw new NotImplementedException();
        }

        public List<Task> GetTasksByProjectId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Task> GetTasksByUserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
