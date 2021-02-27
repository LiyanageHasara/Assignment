<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="Assignment.Application.Views.Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            <div class="col-md-12 col-md-offset-1">
                                <h1>Project Details</h1>
                            </div>
                        </header>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Project Name" runat="server" />
                                        <asp:TextBox runat="server" ID="project_name" Enabled="true" CssClass="form-control input-sm" placeholder="Enter Project Name" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label Text="Upload Files" runat="server" />
                                        <asp:FileUpload runat="server" ID="file_upload" Enabled="true" CssClass="form-control input-sm" placeholder="Enter Project Cost" AllowMultiple="True" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 col-md-offset-1">
                                    <asp:Button Text="Sumbit" ID="btnsave" runat="server" CssClass="btn btn-primary" Width="100px" OnClick="btnsave_Click" />
                                </div>

                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
