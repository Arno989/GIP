<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage2.0.Master" AutoEventWireup="true" CodeBehind="ClientPage.aspx.cs" Inherits="Presentation.Site.ClientSite" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
    <title>Clients</title>
</asp:Content>

<asp:Content ID="Form" ContentPlaceHolderID="Form" runat="server">
    <div class="view-page">
    <div class="form">
        <h2>Clients</h2>
        <hr />
        <div class="gridview">
            <asp:GridView ID="GridView" runat="server" AllowSorting="True" OnSorting="Sort" onrowdatabound="Gridview_RowDataBound" AutoGenerateColumns="False" DataKeyNames="Client_ID" CssClass="gv">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"/>
                    <asp:BoundField DataField="Adress" HeaderText="Adress" SortExpression="Adress"/>
                    <asp:BoundField DataField="Postal_Code" HeaderText="Postal Code" SortExpression="Postal_Code"/>
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City"/>
                    <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country"/>
                    <asp:BoundField DataField="Contact_Person" HeaderText="Contact Person" SortExpression="Contact_Person"/>
                    <asp:BoundField DataField="Invoice_Info" HeaderText="Invoice Info" SortExpression="Invoice_Info"/>
                    <asp:BoundField DataField="Kind_of_Client" HeaderText="Kind of Client" SortExpression="Kind_of_Client"/>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </div>
</asp:Content>