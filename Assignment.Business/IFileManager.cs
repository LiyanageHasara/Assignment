using Assignment.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Business
{
    public interface IFileManager
    {
        /// <summary>
        /// Get Files By ProjectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        List<File> GetFilesByProjectId(int projectId);
    }
}
