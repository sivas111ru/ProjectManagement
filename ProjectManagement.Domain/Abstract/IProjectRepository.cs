using System;
using System.Collections.Generic;
using System.Linq;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Domain.Abstract
{
    public interface IProjectRepository
    {
        IQueryable<Project> Projects { get; }
        IQueryable<UserProjectMap> UserProjectMaps { get; }

        string GetName(int id);

        bool CreateProject(Project project);

        List<Project> GetLastNProjects(int projectNumber);

        List<Project> GetProjects();

        Project GetProjectById(int projectId);

        List<Task> GetProjectsTasks(int id);

        bool EditProject(Project project);

        bool DeleteProject(int projectId);

        List<User> GetAllUsersByProjectId(int id);

        bool AddUserToProject(int usrId, int prjId, int accessLvl);

        bool DeleteUserFromProject(int userId, int prjId);
    }
}
