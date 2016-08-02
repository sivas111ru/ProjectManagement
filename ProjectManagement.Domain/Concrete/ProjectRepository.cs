using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Domain.Abstract;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Domain.Concrete
{
    public class ProjectRepository: BaseRepository, IProjectRepository
    {
        public bool CreateProject(Project project)
        {
            dbContext.Projects.AddOrUpdate(project);
            return true;
        }

        public List<Project> GetLastNProjects(int projectNumber)
        {
            return dbContext.Projects.OrderByDescending(p => p.createDate).Take(projectNumber).ToList();
        }

        public List<Project> GetProjects()
        {
            return dbContext.Projects.ToList();
        }

        public Project GetProjectById(int projectId)
        {
            return dbContext.Projects.FirstOrDefault(p => p.id.Equals(projectId));
        }

        public bool EditProject(Project project)
        {
            dbContext.Projects.AddOrUpdate(project);
            return true;
        }

        public bool DeleteProject(int projectId)
        {
            var project = dbContext.Projects.FirstOrDefault(p => p.id.Equals(projectId));

            if (project == null)
                return false;

            project.active = false;

            dbContext.Projects.AddOrUpdate(project);

            return true;
        }
    }
}
