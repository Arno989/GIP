<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage2.0.Master" AutoEventWireup="true" CodeBehind="DoctorPage.aspx.cs" Inherits="Presentation.Site.DoctorPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Doctors</title>
</asp:Content>

<asp:Content ID="Form" ContentPlaceHolderID="Form" runat="server">
    <div class="view-page">
    <div class="form">
        <h2>Doctors</h2>
        <hr />
        <div class="gridview">
            <asp:GridView ID="GridView" runat="server" AllowSorting="True" OnSorting="Sort" onrowdatabound="Gridview_RowDataBound" AutoGenerateColumns="False" DataKeyNames="Doctor_ID" CssClass="gv">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"/>
                    <asp:BoundField DataField="Email" HeaderText="E-mail" SortExpression="Email"/>
                    <asp:BoundField DataField="Phone1" HeaderText="Phone 1" SortExpression="Phone1"/>
                    <asp:BoundField DataField="Phone2" HeaderText="Phone 2" SortExpression="Phone2"/>
                    <asp:BoundField DataField="Adress" HeaderText="Adress" SortExpression="Adress"/>
                    <asp:BoundField DataField="Postal_Code" HeaderText="Postal Code" SortExpression="Postal_Code"/>
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City"/>
                    <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country"/>
                    <asp:BoundField DataField="Specialisation" HeaderText="Specialisation" SortExpression="Specialisation"/>
                    <asp:BoundField DataField="CV" HeaderText="CV" SortExpression="CV"/>
                    <asp:TemplateField HeaderText="Hospitals" ItemStyle-CssClass="tdlb">
                        <ItemTemplate>
                            <asp:ListBox runat="server" ID="lbRel1" CssClass="lb"></asp:ListBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </div>
</asp:Content>