using Assignment.Common.DTO;
using Assignment.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DataAccess
{
    /// <summary>
    /// This class contains method implementations related to Project service
    /// </summary>
    public class ProjectService : IProjectService
    {
        /// <summary>
        /// Delete Project: ToDo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get allproject: ToDo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Project GetProject(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get project list
        /// </summary>
        /// <returns></returns>
        public IList<Project> GetProjects()
        {
            var projectsDataSet = DataManager.ExecuteReader("SELECT * FROM Project");
            IList<Project> projects = new List<Project>();
            foreach (DataRow row in projectsDataSet.Tables[0].Rows)
            {
                projects.Add(new Project
                {
                    ID = row.Field<int>("ProjectId"),
                    Name = row.Field<string>("ProjectName")
                });
            }

            return projects;
        }

        /// <summary>
        /// Insert Project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public bool InsertProject(Project project)
        {
            try
            {
                List<SqlParameter> projectParameterList = new List<SqlParameter>();
                projectParameterList.Add(new SqlParameter("@name", project.Name));
                if (DataManager.ExecuteQuery(Constants.InsertProjectProcedureName, projectParameterList))
                {
                    var files = project.Files;
                    if (files != null && files.Any())
                    {
                        project.ID = DataManager.GetLastRecordIdentity(Constants.ProjectTableName);
                        foreach (var file in files)
                        {
                            List<SqlParameter> fileParameterList = new List<SqlParameter>();
                            fileParameterList.Add(new SqlParameter("@name", file.Name));
                            fileParameterList.Add(new SqlParameter("@projectId", project.ID));
                            //DataManager.ExecuteQuery(Constants.InsertFileProcedureName, fileParameterList);
                            if (!DataManager.ExecuteQuery(Constants.InsertFileProcedureName, fileParameterList))
                            {
                                throw new Exception($"Error occurred in file insert process | project ID: {project.ID}");
                            }
                        }
                        return true;

                    }
                    else
                    {
                        throw new Exception($"No files found | project ID: {project.ID}");
                    }
                }
                else 
                {
                    throw new Exception("Error occurred in project insert process.");
                }
                
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}
