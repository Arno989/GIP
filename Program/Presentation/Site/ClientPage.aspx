<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSite.Master" AutoEventWireup="true" CodeBehind="ClientPage.aspx.cs" Inherits="Presentation.Site.ClientSite" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
    <title>Clients</title>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
    <div class="headLeft"><p class="uppercase">Clients</p></div>
	<div class="headRight">
        <asp:LinkButton id="btnAdd" runat="server" OnClick="Add" ToolTip="Add one or more client(s)" ><i class="material-icons">add</i></asp:LinkButton>
        <asp:LinkButton id="btnEdit" runat="server" OnClick="Edit" Tooltip="Edit selected row(s)"><i class="material-icons">edit</i></asp:LinkButton>
        <asp:LinkButton id="btnDelete" runat="server" OnClick="Delete" ToolTip="Delete selected row(s)"><i class="material-icons">delete</i></asp:LinkButton>
	</div>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
    <asp:GridView ID="GridView" runat="server" AllowSorting="True" OnSorting="Sort" onrowdatabound="Gridview_RowDataBound" AutoGenerateColumns="False" DataKeyNames="Client_ID"  RowStyle-CssClass="gvtr">
        <Columns>
            <asp:TemplateField ShowHeader="false" HeaderStyle-Width="50px" ItemStyle-CssClass="gvtd">
                <ItemTemplate>
                    <label class="container">
                        <asp:CheckBox ID="CheckBox" runat="server" />
                        <span class="checkmark"></span>
                    </label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" HeaderStyle-ForeColor="Black" ItemStyle-CssClass="gvtd"/>
            <asp:BoundField DataField="Adress" HeaderText="Adress" SortExpression="Adress" HeaderStyle-ForeColor="Black" ItemStyle-CssClass="gvtd"/>
            <asp:BoundField DataField="Postal_Code" HeaderText="Postal Code" SortExpression="Postal_Code" HeaderStyle-ForeColor="Black" ItemStyle-CssClass="gvtd"/>
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" HeaderStyle-ForeColor="Black" ItemStyle-CssClass="gvtd"/>
            <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" HeaderStyle-ForeColor="Black" ItemStyle-CssClass="gvtd"/>
            <asp:BoundField DataField="Contact_Person" HeaderText="Contact Person" SortExpression="Contact_Person" HeaderStyle-ForeColor="Black" ItemStyle-CssClass="gvtd"/>
            <asp:BoundField DataField="Invoice_Info" HeaderText="Invoice Info" SortExpression="Invoice_Info" HeaderStyle-ForeColor="Black" ItemStyle-CssClass="gvtd"/>
            <asp:BoundField DataField="Kind_of_Client" HeaderText="Kind of Client" SortExpression="Kind_of_Client" HeaderStyle-ForeColor="Black" ItemStyle-CssClass="gvtd"/>
        </Columns>
    </asp:GridView>
</asp:Content>