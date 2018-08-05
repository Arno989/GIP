<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage2.0.Master" AutoEventWireup="true" CodeBehind="StudyCoordinatorPage.aspx.cs" Inherits="Presentation.Site.StudyCoordinatorPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Study Coordinators</title>
</asp:Content>

<asp:Content ID="Form" ContentPlaceHolderID="Form" runat="server">
    <div class="view-page">
    <div class="form">
        <h2>Study Coordinators</h2>
        <hr />
        <div class="gridview">
            <asp:GridView ID="GridView" runat="server" AllowSorting="True" OnSorting="Sort" onrowdatabound="Gridview_RowDataBound" AutoGenerateColumns="False" DataKeyNames="StudyCoordinator_ID" CssClass="gv">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"/>
                    <asp:BoundField DataField="CV" HeaderText="CV" SortExpression="CV"/>
                    <asp:BoundField DataField="Email" HeaderText="E-mail" SortExpression="Email"/>
                    <asp:BoundField DataField="Phone1" HeaderText="Phone 1" SortExpression="Phone1"/>
                    <asp:BoundField DataField="Phone2" HeaderText="Phone 2" SortExpression="Phone2"/>
                    <asp:BoundField DataField="Specialisation" HeaderText="Specialisation" SortExpression="Specialisation"/>
                    <asp:TemplateField HeaderText="Doctors" ItemStyle-CssClass="tdlb" HeaderStyle-ForeColor="Black" >
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