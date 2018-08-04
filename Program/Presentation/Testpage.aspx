<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page 2.0.Master" AutoEventWireup="true" CodeBehind="Testpage.aspx.cs" Inherits="Presentation.Testpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Form" ContentPlaceHolderID="Form" runat="server">
    <div class="view-page">
    <div class="form">
        <h1>Administrator</h1>
        <div class="gridview">
            <asp:GridView ID="Gridview" runat="server" AllowSorting="True" OnSorting="Sort" onrowdatabound="Gridview_RowDataBound" AutoGenerateColumns="False" DataKeyNames="User_ID" CssClass="gv" OnSelectedIndexChanged="Gridview_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="40">
                        <ItemTemplate>
                            <asp:Button runat="server" CssClass="gvButton" Text="Edit"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username"/>
                    <asp:BoundField DataField="Email" HeaderText="E-mail" SortExpression="Email"/>
                    <asp:BoundField DataField="Type" HeaderText="Account type" SortExpression="Type"/>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </div>
</asp:Content>
