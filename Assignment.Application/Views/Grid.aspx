<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grid.aspx.cs" Inherits="Assignment.Application.Views.Grid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server">Project Details</asp:Label>
            <asp:GridView ID="projectGridView" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ProjectId" />
                    <asp:BoundField DataField="Name" HeaderText="ProjectName" />
                    <asp:HyperLinkField Text="See Files" DataNavigateUrlFields="ID,Name" DataNavigateUrlFormatString="ProjectView.aspx?ID={0}&Name={1}" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:Button ID="btnAdd" runat="server" Text="ADD" OnClick="btnAdd_Click" />
    </form>
</body>
</html>
