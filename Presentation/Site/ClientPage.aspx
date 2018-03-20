<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSite.Master" AutoEventWireup="true" CodeBehind="ClientPage.aspx.cs" Inherits="Presentation.Site.ClientSite" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
    <title>Clients</title> 
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
    <div class="headLeft"><p class="uppercase">Clients</p></div>
	<div class="headRight">
        <asp:LinkButton id="btnDelete" runat="server" CssClass="material-icons" OnClick="btnDelete_Click"> <span aria-hidden="true" class="material-icons"></span>delete </asp:LinkButton>
        <a href="../SiteEdit/ClientPageEdit.aspx"><i class="material-icons">create</i></a>
	</div>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
    <%--<body>
    <form id="form1" runat="server">
    <div>
       <asp:GridView ID="GridView1" runat="server" 
        AutoGenerateColumns = "false" Font-Names = "Arial" 
        Font-Size = "11pt" AlternatingRowStyle-BackColor = "#C2D69B"  
        HeaderStyle-BackColor = "green" AllowPaging ="true"   
        OnPageIndexChanging = "OnPaging" OnRowDataBound = "RowDataBound"
        PageSize = "10" >
       <Columns>
        <asp:TemplateField>
            <HeaderTemplate>
                <asp:CheckBox ID="chkAll" runat="server" onclick = "checkAll(this);" />
            </HeaderTemplate> 
            <ItemTemplate>
                <asp:CheckBox ID="CheckBox1" runat="server" onclick = "Check_Click(this)"/>
            </ItemTemplate>
        </asp:TemplateField> 
        <asp:BoundField ItemStyle-Width = "150px" DataField = "CustomerID" HeaderText = "CustomerID" />
        <asp:BoundField ItemStyle-Width = "150px" DataField = "City" HeaderText = "City"/>
        <asp:BoundField ItemStyle-Width = "150px" DataField = "Country" HeaderText = "Country"/>
        <asp:BoundField ItemStyle-Width = "150px" DataField = "PostalCode" HeaderText = "PostalCode"/>
       </Columns> 
       <AlternatingRowStyle BackColor="#C2D69B"  />
    </asp:GridView> 
    </div>
    
    </form>
</body>--%>
    <asp:GridView ID="GridView" runat="server" AllowSorting="True" OnRowDeleting="GridView_RowDeleting" AutoGenerateColumns="False" DataKeyNames="Client_ID">
        <Columns>
            <%--<asp:TemplateField ShowHeader="false" ItemStyle-CssClass="templateItem" HeaderStyle-CssClass="templateHead">
                <ItemTemplate>
                    <asp:CheckBox ID="cbEdit" runat="server" CssClass="checkbox" />
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField ShowHeader="false" ItemStyle-CssClass="templateItem" HeaderStyle-CssClass="templateHead">
                <HeaderTemplate>   
                            <asp:CheckBox ID="chkAllSelect" runat="server" onclick="CheckAll(this)" />  
                </HeaderTemplate> 
                <ItemTemplate>  
                            <asp:CheckBox ID="CheckBox" runat="server" onclick = "Check_Click(this)" />  
                </ItemTemplate> 
                <%--<ItemTemplate>
                    <label class="container">
                      <input type="checkbox" id="cbEdit" checked="checked" />
                      <span class="checkmark"></span>
                    </label>
                </ItemTemplate>--%>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Name"/>
            <asp:BoundField DataField="Adress" HeaderText="Adress"/>
            <asp:BoundField DataField="Postal_Code" HeaderText="Postal Code"/>
            <asp:BoundField DataField="City" HeaderText="City"/>
            <asp:BoundField DataField="Country" HeaderText="Country"/>
            <asp:BoundField DataField="Contact_Person" HeaderText="Contact Person"/>
            <asp:BoundField DataField="Invoice_Info" HeaderText="Invoice Info"/>
            <asp:BoundField DataField="Kind_of_Client" HeaderText="Kind of Client"/>
        </Columns>
	</asp:GridView>
</asp:Content>

