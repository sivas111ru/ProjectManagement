using System;
using System.Collections.Generic;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Domain.Abstract
{
    public interface IProjectRepository
    {
        bool CreateProject(Project project);

        List<Project> GetLastNProjects(int projectNumber);

        List<Project> GetProjects();

        Project GetProjectById(int projectId);

        bool EditProject(Project project);

        bool DeleteProject(int projectId);
    }
}
