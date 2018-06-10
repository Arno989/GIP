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
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" HeaderStyle-ForeColor="Black"/>
            <asp:BoundField DataField="Start_date" HeaderText="Start Date" SortExpression="Start_date" HeaderStyle-ForeColor="Black"/>
            <asp:BoundField DataField="End_date" HeaderText="End Date" SortExpression="End_date" HeaderStyle-ForeColor="Black"/>            
            <asp:TemplateField HeaderText="CRA's" ItemStyle-CssClass="cellListbox" HeaderStyle-ForeColor="Black">
                <ItemTemplate>
                    <asp:ListBox runat="server" ID="lbRel1" CssClass="listbox"></asp:ListBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Doctors" ItemStyle-CssClass="cellListbox" HeaderStyle-ForeColor="Black">
                <ItemTemplate>
                    <asp:ListBox runat="server" ID="lbRel2" CssClass="listbox"></asp:ListBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Hospitals" ItemStyle-CssClass="cellListbox" HeaderStyle-ForeColor="Black">
                <ItemTemplate>
                    <asp:ListBox runat="server" ID="lbRel3" CssClass="listbox"></asp:ListBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Project Managers" ItemStyle-CssClass="cellListbox" HeaderStyle-ForeColor="Black">
                <ItemTemplate>
                    <asp:ListBox runat="server" ID="lbRel4" CssClass="listbox"></asp:ListBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>