#region Using Directives
using System;
using System.Collections.Generic;
#endregion

namespace Assignment.Common.DTO
{
    /// <summary>
    /// This class contains project related properties.
    /// </summary>
    public class Project : BaseEntity
    {
        /// <summary>
        /// Related file list for project
        /// </summary>
        public IList<File> Files { get; set; }
    }
}
