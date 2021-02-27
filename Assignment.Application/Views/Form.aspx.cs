using Assignment.Business;
using Assignment.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment.Application.Views
{
    public partial class Form : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            ProjectManager projectManager = new ProjectManager();
            Project project = new Project();
            project.Name = project_name.Text;

            List<File> files = new List<File>();
            if((project_name.Text == "" || project_name.Text == null) && !file_upload.HasFiles)
            {
                Response.Write("<script>alert('All fields are required!')</script>");
                return;
            }
            else if (project_name.Text == "" || project_name.Text == null)
            {
                Response.Write("<script>alert('Name cannot be empty!')</script>");
                return;
            }
            else if (!file_upload.HasFiles)
            {
                Response.Write("<script>alert('Make sure atleast one file is selected')</script>");
                return;
            }
            else
            {
                foreach (HttpPostedFile uploadedFile in file_upload.PostedFiles)
                {
                    string guid = Guid.NewGuid().ToString();
                    string fileName = guid + uploadedFile.FileName;

                    uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Files/"), fileName));
                    
                    File file = new File();
                    file.Name = fileName;

                    files.Add(file);
                }
            }
            project.Files = files;
            bool success = projectManager.InsertProject(project);

            if (success)
            {
                Response.Redirect("Grid.aspx");
            }
            else
            {
                Response.Write("<script>alert('Data insertion failed!')</script>");
            }

        }






    }
}