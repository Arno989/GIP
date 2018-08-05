<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.0.Master" AutoEventWireup="true" CodeBehind="Testpage.aspx.cs" Inherits="Presentation.Testpage" %>
<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
    <title>Administrator page</title>
</asp:Content>

<asp:Content ID="Form" ContentPlaceHolderID="Form" runat="server">
    <div class="view-page">
    <div class="form">
        <h2>Account management</h2>
        <hr />
        <div class="gridview">
            <asp:GridView ID="Gridview" runat="server" AllowSorting="True" OnSorting="Sort" onrowdatabound="Gridview_RowDataBound" AutoGenerateColumns="False" DataKeyNames="User_ID" CssClass="gv" OnSelectedIndexChanged="Gridview_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username"/>
                    <asp:BoundField DataField="Email" HeaderText="E-mail" SortExpression="Email"/>
                    <asp:BoundField DataField="Type" HeaderText="Account type" SortExpression="Type"/>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </div>
</asp:Content>
