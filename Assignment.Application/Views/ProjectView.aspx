<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectView.aspx.cs" Inherits="Assignment.Application.Views.ProjectView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="projectGridView" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="projectGridView_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Project Files" />
                    <asp:HyperLinkField Text="Download" DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Files.aspx?Name={0}" />
                </Columns>
            </asp:GridView>
        <div>
        </div>
    </form>
</body>
</html>
