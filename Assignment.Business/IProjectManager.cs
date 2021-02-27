using Assignment.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Business
{
    public interface IProjectManager
    {
        List<Project> GetProjects();

        bool InsertProject(Project project);
    }
}
