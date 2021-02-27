using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Assignment.Business;

namespace Assignment.Application.Views
{
    public partial class Grid : System.Web.UI.Page
    {
        private IProjectManager _projectManager = new ProjectManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            var projects = _projectManager.GetProjects();
            projectGridView.DataSource = projects;
            projectGridView.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Form.aspx");
        }
    }
}