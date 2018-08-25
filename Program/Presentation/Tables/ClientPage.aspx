<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage2.0.Master" AutoEventWireup="true" CodeBehind="ClientPage.aspx.cs" Inherits="Presentation.ClientPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
    <title>Clients</title>
</asp:Content>

<asp:Content ID="Form" ContentPlaceHolderID="Form" runat="server">

    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>

    <div class="view-page">
    <div class="form">
        <div class="titleBar">
            <h2>Clients</h2>
            <asp:LinkButton runat="server" ID="btnAdd" ToolTip="Add record" OnClick="BtnAdd_Click" CssClass="rightIcon"><i class="material-icons">add</i></asp:LinkButton>
        </div>
        <hr />
        <div class="gridview">
            <asp:UpdatePanel ID="gvUpdatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="Gridview" runat="server" AllowSorting="True" OnSorting="Sort" AutoGenerateColumns="False" DataKeyNames="ID" CssClass="gv" OnSelectedIndexChanged="Gridview_SelectedIndexChanged" OnRowDataBound="Gridview_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderStyle-Width="44px">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" autopostback="false" ToolTip="Edit record" data-toggle="modal" data-target="#exampleModal"><i class="material-icons">edit</i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
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
                                <h1>Client details</h1>
                                <asp:TextBox runat="server" ID="tbName" placeholder="Name*" CssClass="input" OnTextChanged="Tb_TextChanged"></asp:TextBox>
                                <asp:TextBox runat="server" ID="tbAdress" placeholder="Adress" CssClass="input" OnTextChanged="Tb_TextChanged"></asp:TextBox>
                                <asp:TextBox runat="server" ID="tbPostalCode" placeholder="Postal Code" CssClass="input" OnTextChanged="Tb_TextChanged"></asp:TextBox>
                                <asp:TextBox runat="server" ID="tbCity" placeholder="City" CssClass="input" OnTextChanged="Tb_TextChanged"></asp:TextBox>
                                <asp:TextBox runat="server" ID="tbCountry" placeholder="Country" CssClass="input" OnTextChanged="Tb_TextChanged"></asp:TextBox>
                                <asp:TextBox runat="server" ID="tbContactPerson" placeholder="Contact Person" CssClass="input" OnTextChanged="Tb_TextChanged"></asp:TextBox>
                                <asp:TextBox runat="server" ID="tbInvoiceInfo" placeholder="Invoice Info" CssClass="input" OnTextChanged="Tb_TextChanged"></asp:TextBox>
                                <asp:TextBox runat="server" ID="tbKindOfClient" placeholder="Kind Of Client" CssClass="input" OnTextChanged="Tb_TextChanged"></asp:TextBox>
                                <asp:Label runat="server" ID="lbError" Visible="true" CssClass="error"></asp:Label>
                                
                                <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="buttonLeft" OnClick="BtnSave_Click"/>
                                <asp:Button runat="server" ID="btnExit" Text="Exit" CssClass="buttonRight" data-dismiss="modal"/>
                                <asp:LinkButton runat="server" ID="lnkDelete" Text="Delete account" CssClass="linkButton" OnClick="LnkDelete_Click"></asp:LinkButton>
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