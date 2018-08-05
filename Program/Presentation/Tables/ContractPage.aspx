<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage2.0.Master" AutoEventWireup="true" CodeBehind="ContractPage.aspx.cs" Inherits="Presentation.Site.ContractPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Client Contracts</title>
</asp:Content>

<asp:Content ID="Form" ContentPlaceHolderID="Form" runat="server">
    <div class="view-page">
    <div class="form">
        <h2>Client Contracts</h2>
        <hr />
        <div class="gridview">
            <asp:GridView ID="GridView" runat="server" AllowSorting="True" OnSorting="Sort" onrowdatabound="Gridview_RowDataBound" AutoGenerateColumns="False" DataKeyNames="Contract_ID" CssClass="gv">
                <Columns>
                    <asp:BoundField DataField="Legal_country" HeaderText="Legal Country" SortExpression="Legal_country"/>
                    <asp:BoundField DataField="Fee" HeaderText="Fee" SortExpression="Fee"/>
                    <asp:BoundField DataField="Start_Date" HeaderText="Start Date" SortExpression="Start_Date"/>
                    <asp:BoundField DataField="End_Date" HeaderText="End Date" SortExpression="End_Date"/>
                    <asp:TemplateField HeaderText="Project" SortExpression="Project_ID">
                        <ItemTemplate>
                            <asp:Label ID="lbProject" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Client" SortExpression="Client_ID">
                        <ItemTemplate>
                            <asp:Label ID="lbClient" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </div>
</asp:Content>