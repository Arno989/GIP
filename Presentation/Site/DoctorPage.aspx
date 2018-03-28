<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSite.Master" AutoEventWireup="true" CodeBehind="DoctorPage.aspx.cs" Inherits="Presentation.Site.DoctorPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Doctors</title>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<div class="headLeft"><p class="uppercase">Doctors</p></div>
	<div class="headRight">
        <asp:LinkButton id="btnAdd" runat="server" OnClick="Add" ToolTip="Add one or more client(s)" ><i class="material-icons">add</i></asp:LinkButton>
        <asp:LinkButton id="btnEdit" runat="server" OnClick="Edit" Tooltip="Edit selected row(s)"><i class="material-icons">edit</i></asp:LinkButton>
        <asp:LinkButton id="btnDelete" runat="server" OnClick="Delete" ToolTip="Delete selected row(s)"><i class="material-icons">delete</i></asp:LinkButton>
	</div>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
    <asp:GridView ID="GridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Doctor_ID">
        <Columns>
            <asp:TemplateField HeaderStyle-CssClass="templateHead" ItemStyle-CssClass="templateItem" ShowHeader="false">
                <ItemTemplate>
                    <label class="container">
                        <asp:CheckBox ID="CheckBox" runat="server" />
                        <span class="checkmark"></span>
                    </label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Email" HeaderText="E-mail" />
            <asp:BoundField DataField="Phone1" HeaderText="Phone 1" />
            <asp:BoundField DataField="Phone2" HeaderText="Phone 2" />
            <asp:BoundField DataField="Adress" HeaderText="Adress" />
            <asp:BoundField DataField="Postal_Code" HeaderText="Postal Code" />
            <asp:BoundField DataField="City" HeaderText="City" />
            <asp:BoundField DataField="Country" HeaderText="Country" />
            <asp:BoundField DataField="Specialisation" HeaderText="Spaecialisation" />
            <asp:BoundField DataField="CV" HeaderText="CV" />
        </Columns>
    </asp:GridView>
</asp:Content>