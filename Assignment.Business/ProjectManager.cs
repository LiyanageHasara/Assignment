using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.DataAccess;
using Assignment.Common.DTO;

namespace Assignment.Business
{
    public class ProjectManager : IProjectManager
    {
        private readonly IProjectService _projectService;

        public ProjectManager() : this(new ProjectService()) {}
        public ProjectManager(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public List<Project> GetProjects() {
            return _projectService.GetProjects().ToList();
        }

        public bool InsertProject(Project project)
        {
            return _projectService.InsertProject(project);
        }
    }
}
