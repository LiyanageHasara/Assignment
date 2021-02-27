using Assignment.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DataAccess
{
    public interface IFileService
    {
        /// <summary>
        /// Get Files By ProjectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        IList<File> GetFilesByProjectId(int projectId);
    }
}
