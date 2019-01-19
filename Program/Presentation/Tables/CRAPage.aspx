<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage2.0.Master" AutoEventWireup="true" CodeBehind="CRAPage.aspx.cs" Inherits="Presentation.Site.CRAPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>CRA's</title>
</asp:Content>

<asp:Content ID="Form" ContentPlaceHolderID="Form" runat="server">

    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>

    <div class="view-page">
    <div class="form">
        <div class="titleBar">
            <h2>CRA Management</h2>
            <asp:LinkButton runat="server" ID="btnAdd" ToolTip="Add record" OnClick="BtnAdd_Click" CssClass="rightIcon"><i class="material-icons">add</i></asp:LinkButton>
        </div>
        <hr />
        <div class="gridview">
            <asp:UpdatePanel ID="gvUpdatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="Gridview" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" CssClass="gv" OnSelectedIndexChanged="Gridview_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderStyle-Width="44px">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" autopostback="true" ToolTip="Edit record" OnClick="BtnEdit_Click"><i class="material-icons">edit</i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"/>
                            <asp:BoundField DataField="CV" HeaderText="CV" SortExpression="CV"/>
                            <asp:BoundField DataField="Email" HeaderText="E-mail" SortExpression="Email"/>
                            <asp:BoundField DataField="Phone1" HeaderText="Phone 1" SortExpression="Phone1"/>
                            <asp:BoundField DataField="Phone2" HeaderText="Phone 2" SortExpression="Phone2"/>
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
              <asp:UpdatePanel ID="modUpdatePanel" runat="server" UpdateMode="Conditional">
                  <ContentTemplate>
                     <div class="login-page">
                        <div class="edit">
                            <div class="form">
                                <h1>Account details</h1>
                                <asp:TextBox runat="server" ID="tbName" placeholder="Name *" CssClass="input" OnTextChanged="Tb_TextChanged"></asp:TextBox>
                                <asp:TextBox runat="server" ID="tbCV" placeholder="CV" CssClass="input" OnTextChanged="Tb_TextChanged"></asp:TextBox>
                                <asp:TextBox runat="server" ID="tbEmail" placeholder="Email *" CssClass="input" OnTextChanged="Tb_TextChanged"></asp:TextBox>
                                <asp:TextBox runat="server" ID="tbPhone1" placeholder="Phone 1" CssClass="input" OnTextChanged="Tb_TextChanged"></asp:TextBox>
                                <asp:TextBox runat="server" ID="tbPhone2" placeholder="Phone 2" CssClass="input" OnTextChanged="Tb_TextChanged"></asp:TextBox>
                                <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="buttonLeft" OnClick="BtnSave_Click"/>
                                <asp:Button runat="server" ID="btnExit" Text="Exit" CssClass="buttonRight" data-dismiss="modal"/>
                                <asp:LinkButton runat="server" ID="lnkDelete" Text="Delete account" CssClass="linkButton" OnClick="LnkDelete_Click"></asp:LinkButton>
                                <br/> <asp:Label runat="server" ID="lbNotification" Visible="false" CssClass="notification"></asp:Label>
                            </div>
                        </div>
                     </div>
                </ContentTemplate>
             </asp:UpdatePanel>
          </div>
        </div>
      </div>
    </div>

</asp:Content>