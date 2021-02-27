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
        IList<File> GetFilesByProjectId(int projectId);
    }
}
