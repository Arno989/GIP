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
    <asp:GridView ID="GridView" runat="server" AllowSorting="True" OnSorting="Sort" onrowdatabound="Gridview_RowDataBound" AutoGenerateColumns="False" DataKeyNames="Doctor_ID">
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
            <asp:BoundField DataField="Phone1" HeaderText="Phone 1" SortExpression="Phone1" HeaderStyle-ForeColor="Black"/>
            <asp:BoundField DataField="Phone2" HeaderText="Phone 2" SortExpression="Phone2" HeaderStyle-ForeColor="Black"/>
            <asp:BoundField DataField="Adress" HeaderText="Adress" SortExpression="Adress" HeaderStyle-ForeColor="Black"/>
            <asp:BoundField DataField="Postal_Code" HeaderText="Postal Code" SortExpression="Postal_Code" HeaderStyle-ForeColor="Black"/>
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" HeaderStyle-ForeColor="Black"/>
            <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" HeaderStyle-ForeColor="Black"/>
            <asp:BoundField DataField="Specialisation" HeaderText="Specialisation" SortExpression="Specialisation" HeaderStyle-ForeColor="Black"/>
            <asp:BoundField DataField="CV" HeaderText="CV" SortExpression="CV" HeaderStyle-ForeColor="Black"/>
            <asp:TemplateField HeaderText="Hospitals" ItemStyle-CssClass="cellListbox" HeaderStyle-ForeColor="Black">
                <ItemTemplate>
                    <asp:ListBox runat="server" ID="lbRel1" CssClass="listbox"></asp:ListBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>