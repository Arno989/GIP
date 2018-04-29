<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSite.Master" AutoEventWireup="true" CodeBehind="StudyCoördinatorPage.aspx.cs" Inherits="Presentation.Site.StudyCoördinatorPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Study Coordinators</title>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<div class="headLeft"><p class="uppercase">Study Coordinators</p></div>
	<div class="headRight">
        <asp:LinkButton id="btnAdd" runat="server" OnClick="Add" ToolTip="Add one or more client(s)" ><i class="material-icons">add</i></asp:LinkButton>
        <asp:LinkButton id="btnEdit" runat="server" OnClick="Edit" Tooltip="Edit selected row(s)"><i class="material-icons">edit</i></asp:LinkButton>
        <asp:LinkButton id="btnDelete" runat="server" OnClick="Delete" ToolTip="Delete selected row(s)"><i class="material-icons">delete</i></asp:LinkButton>
	</div>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
	<asp:GridView ID="GridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="SC_ID">
        <Columns>
            <asp:TemplateField ShowHeader="false" HeaderStyle-Width="50px" >
                <ItemTemplate>
                    <label class="container">
                        <asp:CheckBox ID="CheckBox" runat="server" />
                        <span class="checkmark"></span>
                    </label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="CV" HeaderText="CV" />
            <asp:BoundField DataField="Email" HeaderText="E-mail" />
            <asp:BoundField DataField="Phone1" HeaderText="Phone 1" />
            <asp:BoundField DataField="Phone2" HeaderText="Phone 2" />
            <asp:BoundField DataField="Specialisation" HeaderText="Specialisation" />
            <asp:TemplateField HeaderText="Doctors" ItemStyle-CssClass="cellListbox">
                <ItemTemplate>
                    <asp:ListBox runat="server" ID="lbRel1" CssClass="listbox"></asp:ListBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>