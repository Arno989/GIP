<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.0.Master" AutoEventWireup="true" CodeBehind="AdministratorPage.aspx.cs" Inherits="Presentation.Testpage" %>
<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
    <title>Administrator page</title>
</asp:Content>

<asp:Content ID="Form" ContentPlaceHolderID="Form" runat="server">
    <div class="view-page">
    <div class="form">
        <h2>Account management</h2>
        <hr />
        <div class="gridview">
            <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="Gridview" runat="server" AllowSorting="True" OnSorting="Sort" AutoGenerateColumns="False" DataKeyNames="User_ID" CssClass="gv" EnableModelValidation="true" OnSelectedIndexChanged="Gridview_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderStyle-Width="49px">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" autopostback="false" ToolTip="Edit record" data-toggle="modal" data-target="#exampleModal"><i class="material-icons">edit</i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username"/>
                            <asp:BoundField DataField="Email" HeaderText="E-mail" SortExpression="Email"/>
                            <asp:BoundField DataField="Type" HeaderText="Account type" SortExpression="Type"/>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </div>
        
<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-body">
         <div class="login-page">
            <div class="edit">
                <div class="form">
                    <h1>Account details</h1>
                    <asp:TextBox runat="server" ID="tbUsername" placeholder="username" CssClass="input" OnTextChanged="tb_TextChanged"></asp:TextBox>
                    <asp:Label runat="server" ID="lbErrorUsername" Visible="true" CssClass="error"></asp:Label>
                    <asp:TextBox runat="server" ID="tbEmail" placeholder="email adress" CssClass="input" OnTextChanged="tb_TextChanged"></asp:TextBox>
                    <asp:TextBox runat="server" ID="tbPasswordNew" placeholder="new password" TextMode="Password" CssClass="input" OnTextChanged="tb_TextChanged"></asp:TextBox>
                    <asp:Label runat="server" ID="lbErrorPassword" Visible="false" CssClass="error"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddAccountType" CssClass="dropdown">
                        <asp:ListItem>Admin</asp:ListItem>
                        <asp:ListItem>User</asp:ListItem>
                        <asp:ListItem>Guest</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button runat="server" ID="Button1" Text="Save" CssClass="buttonLeft" OnClick="btnSave_Click" data-dismiss="modal"/>
                    <asp:Button runat="server" ID="Button2" Text="Exit" CssClass="buttonRight" OnClick="btnExit_Click"/>
                    <asp:LinkButton runat="server" ID="lnkDelete" Text="Delete account" CssClass="linkButton" OnClick="lnkDelete_Click"></asp:LinkButton>
                </div>
            </div>
         </div>
      </div>
    </div>
  </div>
</div>

</asp:Content>
