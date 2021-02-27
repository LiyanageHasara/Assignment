using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment.Application.Views
{
    public partial class Files : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Name"]))
                {
                    
                    string fileName = Request.QueryString["Name"].ToString();
                    string contentType = MimeMapping.GetMimeMapping(fileName);
                    string filePath = Server.MapPath("~/Files/" + fileName);
                    Response.ContentType = contentType;
                    Response.WriteFile(filePath);
                    Response.End();
                }
            }
        }
    }
}