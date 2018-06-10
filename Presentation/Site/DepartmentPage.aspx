<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSite.Master" AutoEventWireup="true" CodeBehind="DepartmentPage.aspx.cs" Inherits="Presentation.Site.DepartmentPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Departments</title>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<div class="headLeft"><p class="uppercase">Departments</p></div>
	<div class="headRight">
        <asp:LinkButton id="btnAdd" runat="server" OnClick="Add" ToolTip="Add one or more client(s)" ><i class="material-icons">add</i></asp:LinkButton>
        <asp:LinkButton id="btnEdit" runat="server" OnClick="Edit" Tooltip="Edit selected row(s)"><i class="material-icons">edit</i></asp:LinkButton>
        <asp:LinkButton id="btnDelete" runat="server" OnClick="Delete" ToolTip="Delete selected row(s)"><i class="material-icons">delete</i></asp:LinkButton>
	</div>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
    <asp:GridView ID="GridView" runat="server" AllowSorting="True" OnSorting="Sort" onrowdatabound="Gridview_RowDataBound" AutoGenerateColumns="False" DataKeyNames="Department_ID">
        <Columns>
            <asp:TemplateField ShowHeader="false" HeaderStyle-Width="50px" >
                <ItemTemplate>
                    <label class="container">
                        <asp:CheckBox ID="CheckBox" runat="server" />
                        <span class="checkmark"></span>
                    </label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" HeaderStyle-ForeColor="Black"/>
            <asp:BoundField DataField="Email" HeaderText="E-mail" SortExpression="Email" HeaderStyle-ForeColor="Black"/>
            <asp:BoundField DataField="Phone1" HeaderText="Phone" SortExpression="Phone1" HeaderStyle-ForeColor="Black"/>
            <asp:TemplateField HeaderText="Hospital" HeaderStyle-Width="50px" SortExpression="Hospital_ID" HeaderStyle-ForeColor="Black">
                <ItemTemplate>
                    <asp:Label ID="lbHospital" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>