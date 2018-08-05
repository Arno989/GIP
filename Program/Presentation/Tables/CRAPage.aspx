<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage2.0.Master" AutoEventWireup="true" CodeBehind="CRAPage.aspx.cs" Inherits="Presentation.Site.CRAPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>CRA's</title>
</asp:Content>

<asp:Content ID="Form" ContentPlaceHolderID="Form" runat="server">
    <div class="view-page">
    <div class="form">
        <h2>CRA's</h2>
        <hr />
        <div class="gridview">
            <asp:GridView ID="GridView" runat="server" AllowSorting="True" OnSorting="Sort" onrowdatabound="Gridview_RowDataBound" AutoGenerateColumns="False" DataKeyNames="CRA_ID" CssClass="gv">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"/>
                    <asp:BoundField DataField="CV" HeaderText="CV" SortExpression="CV"/>
                    <asp:BoundField DataField="Email" HeaderText="E-mail" SortExpression="Email"/>
                    <asp:BoundField DataField="Phone1" HeaderText="Phone 1" SortExpression="Phone1"/>
                    <asp:BoundField DataField="Phone2" HeaderText="Phone 2" SortExpression="Phone2"/>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </div>
</asp:Content>