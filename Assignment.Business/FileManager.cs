using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.DataAccess;
using Assignment.Common.DTO;


namespace Assignment.Business
{
    public class FileManager : IFileManager
    {
        private readonly IFileService _fileService;

        public FileManager() : this(new FileService()){}

        public FileManager(IFileService fileService)
        {
            _fileService = fileService;
        }

        /// <summary>
        /// Get Files By ProjectId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public List<File> GetFilesByProjectId(int projectId)
        {
            return _fileService.GetFilesByProjectId(projectId).ToList();
        }
    }
}
