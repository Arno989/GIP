<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSite.Master" AutoEventWireup="true" CodeBehind="AdministratorPage.aspx.cs" Inherits="Presentation.Site.AdministratorPage" %>
<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
    <title>Administrator</title>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
    <div class="headLeft"><p class="uppercase">Users</p></div>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
    <asp:GridView ID="Gridview" runat="server" AllowSorting="True" OnSorting="Sort" onrowdatabound="Gridview_RowDataBound" AutoGenerateColumns="False" DataKeyNames="User_ID"  RowStyle-CssClass="gvtr" AutoGenerateSelectButton="True">
        <Columns>
            <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" HeaderStyle-ForeColor="Black" ItemStyle-CssClass="gvtd"/>
            <asp:BoundField DataField="Email" HeaderText="E-mail" SortExpression="Email" HeaderStyle-ForeColor="Black" ItemStyle-CssClass="gvtd"/>
            <asp:BoundField DataField="Type" HeaderText="Account type" SortExpression="Type" HeaderStyle-ForeColor="Black" ItemStyle-CssClass="gvtd"/>
            <asp:TemplateField HeaderText="Password">
                <ItemTemplate>
                    <label>
                    <asp:TextBox runat="server" ID="tbPassword" TextMode="Password" CssClass="input"></asp:TextBox>
                    </label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
