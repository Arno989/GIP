<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdministratorPage.aspx.cs" Inherits="Presentation.Site.AdministratorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administrator Page</title>
    <link rel="stylesheet" href="~/LoginStyleSheet.css" runat="server"/>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
	<link rel="icon" type="image/png" sizes="32x32" href="images/favicon-32x32.png"/>
    
</head>
<body>
    <div class="admin">
    <form runat="server" class="form">
        <div class="gridview">
            <asp:GridView ID="Gridview" runat="server" AllowSorting="True" OnSorting="Sort" onrowdatabound="Gridview_RowDataBound" AutoGenerateColumns="False" DataKeyNames="User_ID" CssClass="gv" OnSelectedIndexChanged="Gridview_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="40">
                        <ItemTemplate>
                            <asp:Button runat="server" CssClass="gvButton" Text="Edit"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username"/>
                    <asp:BoundField DataField="Email" HeaderText="E-mail" SortExpression="Email"/>
                    <asp:BoundField DataField="Type" HeaderText="Account type" SortExpression="Type"/>
                </Columns>
            </asp:GridView>
        </div>
    </form>
    </div>
</body>
</html>
