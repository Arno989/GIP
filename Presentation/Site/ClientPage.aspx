<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSite.Master" AutoEventWireup="true" CodeBehind="ClientPage.aspx.cs" Inherits="Presentation.Site.ClientSite" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
    <title>Clients</title>
</asp:Content>



<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
    <div class="headLeft"><p class="uppercase">Clients</p></div>
	<div class="headRight">
        <asp:LinkButton id="btnLoadGridView" runat="server" OnClick="Load_Gridview" > <i class="material-icons">pageview</i> </asp:LinkButton>
        <asp:LinkButton id="btnDelete" runat="server" CssClass="material-icons" OnClick="btnDelete_Click"> <span aria-hidden="true" class="material-icons"></span>delete </asp:LinkButton>
        <a href="../SiteEdit/ClientPageEdit.aspx"><i class="material-icons">create</i></a>
	</div>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Client_ID" OnRowDeleting="GridView_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderStyle-CssClass="templateHead" ItemStyle-CssClass="templateItem" ShowHeader="false">
                        <ItemTemplate>
                            <label class="container">
                            <asp:CheckBox ID="CheckBox" runat="server" />
                            <span class="checkmark"></span>
                            </label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Adress" HeaderText="Adress" />
                    <asp:BoundField DataField="Postal_Code" HeaderText="Postal Code" />
                    <asp:BoundField DataField="City" HeaderText="City" />
                    <asp:BoundField DataField="Country" HeaderText="Country" />
                    <asp:BoundField DataField="Contact_Person" HeaderText="Contact Person" />
                    <asp:BoundField DataField="Invoice_Info" HeaderText="Invoice Info" />
                    <asp:BoundField DataField="Kind_of_Client" HeaderText="Kind of Client" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</asp:Content>