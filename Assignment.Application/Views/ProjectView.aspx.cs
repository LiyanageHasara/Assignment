using Assignment.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment.Application.Views
{
    public partial class ProjectView : System.Web.UI.Page
    {
        private IFileManager _fileManager = new FileManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            int projectId = Int32.Parse(Request.QueryString["ID"]);
            var files = _fileManager.GetFilesByProjectId(projectId);
            projectGridView.DataSource = files;
            projectGridView.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void projectGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}