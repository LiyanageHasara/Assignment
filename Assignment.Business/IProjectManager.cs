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
        /// <summary>
        /// Get Projects
        /// </summary>
        /// <returns></returns>
        List<Project> GetProjects();

        /// <summary>
        /// Insert Project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        bool InsertProject(Project project);
    }
}
