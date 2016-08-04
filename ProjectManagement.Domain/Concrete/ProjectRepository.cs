using System;
using System.CodeDom;
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
        public IQueryable<Project> Projects => dbContext.Projects.AsQueryable();
        public IQueryable<UserProjectMap> UserProjectMaps => dbContext.UserProjectMaps.AsQueryable();

        public string GetName(int id)
        {
            return Projects.FirstOrDefault(p => p.id == id)?.name;
        }
            

        public bool CreateProject(Project project)
        {
            dbContext.Projects.AddOrUpdate(project);
            dbContext.SaveChanges();
            return true;
        }

        public List<Project> GetLastNProjects(int projectNumber)
        {
            return (Projects.OrderByDescending(d => d.createDate).Where(p=>p.active).Take(projectNumber)).ToList();
        }

        public List<Project> GetProjects()
        {
            return dbContext.Projects.Where(p=>p.active).ToList();
        }

        public Project GetProjectById(int projectId)
        {
            return dbContext.Projects.FirstOrDefault(p => p.id.Equals(projectId));
        }

        public bool EditProject(Project project)
        {
            dbContext.Projects.AddOrUpdate(project);
            dbContext.SaveChanges();
            return true;
        }

        public bool DeleteProject(int projectId)
        {
            var project = dbContext.Projects.FirstOrDefault(p => p.id.Equals(projectId));

            if (project == null)
                return false;

            project.active = false;

            dbContext.Projects.AddOrUpdate(project);
            dbContext.SaveChanges();

            return true;
        }

        public List<User> GetAllUsersByProjectId(int id)
        {
            return (from map in dbContext.UserProjectMaps
                where map.active && map.accessLvl > 0 && map.fkUser == id
                join u in dbContext.Users on map.fkUser equals u.id
                select u).ToList();
        }


        public bool AddUserToProject(int usrId, int prjId, int accessLvl)
        {
            try
            {
                UserProjectMap upm = new UserProjectMap
                {
                    active = true,
                    fkProject = prjId,
                    fkUser = usrId,
                    accessLvl = accessLvl
                };

                dbContext.UserProjectMaps.AddOrUpdate(upm);
                dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
             
        }


        public bool DeleteUserFromProject(int userId, int prjId)
        {
            try
            {
                UserProjectMap upm = dbContext.UserProjectMaps.FirstOrDefault(u => u.fkUser.Equals(userId) && u.fkProject.Equals(prjId));

                if (upm == null) return false;

                upm.active = false;

                dbContext.UserProjectMaps.AddOrUpdate(upm);

                dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
