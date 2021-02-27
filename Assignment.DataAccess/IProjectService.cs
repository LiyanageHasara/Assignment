#region Using Directives
using Assignment.Common.DTO;
using System.Collections.Generic; 
#endregion

namespace Assignment.DataAccess
{
    /// <summary>
    /// This interface contains methods related to Project service
    /// </summary>
    public interface IProjectService
    {
        /// <summary>
        /// Add project to database
        /// </summary>
        /// <param name="project">project entity</param>
        /// <returns>Project insert or not</returns>
        bool InsertProject(Project project);

        /// <summary>
        /// Get project by ID:ToDo
        /// </summary>
        /// <param name="id">project ID</param>
        /// <returns>Project data</returns>
        Project GetProject(int id);

        /// <summary>
        /// Delete project:ToDo
        /// </summary>
        /// <param name="project"></param>
        /// <returns>Project delete or not</returns>
        bool DeleteProject(int id);

        /// <summary>
        /// Get all projects
        /// </summary>
        /// <returns>All Projects</returns>
        IList<Project> GetProjects();
    }
}
