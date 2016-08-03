using System;
using System.Collections.Generic;
using System.Linq;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Domain.Abstract
{
    public interface IProjectRepository
    {
        IQueryable<Project> Projects { get; }

        bool CreateProject(Project project);

        List<Project> GetLastNProjects(int projectNumber);

        List<Project> GetProjects();

        Project GetProjectById(int projectId);

        bool EditProject(Project project);

        bool DeleteProject(int projectId);
    }
}
