<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSite.Master" AutoEventWireup="true" CodeBehind="ProjectPage.aspx.cs" Inherits="Presentation.Site.ProjectPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Projects</title>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<div class="headLeft"><p class="uppercase">Projects</p></div>
	<div class="headRight">
        <asp:LinkButton id="btnAdd" runat="server" OnClick="Add" ToolTip="Add one or more client(s)" ><i class="material-icons">add</i></asp:LinkButton>
        <asp:LinkButton id="btnEdit" runat="server" OnClick="Edit" Tooltip="Edit selected row(s)"><i class="material-icons">edit</i></asp:LinkButton>
        <asp:LinkButton id="btnDelete" runat="server" OnClick="Delete" ToolTip="Delete selected row(s)"><i class="material-icons">delete</i></asp:LinkButton>
	</div>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
    <asp:GridView ID="GridView" runat="server" AllowSorting="True" OnSorting="Sort" onrowdatabound="Gridview_RowDataBound" AutoGenerateColumns="False" DataKeyNames="Project_ID" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField ShowHeader="false" HeaderStyle-Width="50px" >
                <ItemTemplate>
                    <label class="container">
                        <asp:CheckBox ID="CheckBox" runat="server" />
                        <span class="checkmark"></span>
                    </label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Title" SortExpression="Title">
                <EditItemTemplate>
                    <asp:Button ID="btnTitle" Visible="false" runat="server"
                        Text='<%# Bind("Title") %>'></asp:Button>
                </EditItemTemplate>
                <ItemTemplate>
                     <asp:Label ID="LabelTitle" runat="server"
                         Text='<%# Bind("Title") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Start Date" SortExpression="Start_date">
                <EditItemTemplate>
                    <asp:Button ID="btnStartDate" Visible="false" runat="server"
                        Text='<%# Bind("Start_date") %>'></asp:Button>
                </EditItemTemplate>
                <ItemTemplate>
                     <asp:Label ID="LabelStartDate" runat="server"
                         Text='<%# Bind("Start_date") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="End Date" SortExpression="End_date">
                <EditItemTemplate>
                    <asp:Button ID="btnEndDate" Visible="false" runat="server"
                        Text='<%# Bind("End_date") %>'></asp:Button>
                </EditItemTemplate>
                <ItemTemplate>
                     <asp:Label ID="LabelEndDate" runat="server"
                         Text='<%# Bind("End_date") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CRA's" ItemStyle-CssClass="cellListbox">
                <ItemTemplate>
                    <asp:ListBox runat="server" ID="lbRel1" CssClass="listbox"></asp:ListBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Doctors" ItemStyle-CssClass="cellListbox">
                <ItemTemplate>
                    <asp:ListBox runat="server" ID="lbRel2" CssClass="listbox"></asp:ListBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Hospitals" ItemStyle-CssClass="cellListbox">
                <ItemTemplate>
                    <asp:ListBox runat="server" ID="lbRel3" CssClass="listbox"></asp:ListBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Project Managers" ItemStyle-CssClass="cellListbox">
                <ItemTemplate>
                    <asp:ListBox runat="server" ID="lbRel4" CssClass="listbox"></asp:ListBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>