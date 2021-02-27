using Assignment.Common.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DataAccess
{
    public class FileService : IFileService
    {
        /// <summary>
        /// Get Files By ProjectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public IList<File> GetFilesByProjectId(int projectId)
        {
            string query = "SELECT * FROM Files Where ProjectId=" + projectId;
            var fileDataSet = DataManager.ExecuteReader(query);
            IList<File> files = new List<File>();
            foreach (DataRow row in fileDataSet.Tables[0].Rows)
            {
                files.Add(new File
                {
                    ID = row.Field<int>("FileId"),
                    Name = row.Field<string>("FileName")
                });
            }

            return files;
        }
    }
}
