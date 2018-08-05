<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage2.0.Master" AutoEventWireup="true" CodeBehind="ProjectPage.aspx.cs" Inherits="Presentation.Site.ProjectPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Projects</title>
</asp:Content>

<asp:Content ID="Form" ContentPlaceHolderID="Form" runat="server">
    <div class="view-page">
    <div class="form">
        <h2>Projects</h2>
        <hr />
        <div class="gridview">
            <asp:GridView ID="GridView" runat="server" AllowSorting="True" OnSorting="Sort" onrowdatabound="Gridview_RowDataBound" AutoGenerateColumns="False" DataKeyNames="Project_ID" CssClass="gv">
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"/>
                    <asp:BoundField DataField="Start_date" HeaderText="Start Date" SortExpression="Start_date"/>
                    <asp:BoundField DataField="End_date" HeaderText="End Date" SortExpression="End_date"/>            
                    <asp:TemplateField HeaderText="CRA's" ItemStyle-CssClass="tdlb">
                        <ItemTemplate>
                            <asp:ListBox runat="server" ID="lbRel1" CssClass="lb"></asp:ListBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Doctors" ItemStyle-CssClass="tdlb">
                        <ItemTemplate>
                            <asp:ListBox runat="server" ID="lbRel2" CssClass="lb"></asp:ListBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hospitals" ItemStyle-CssClass="tdlb">
                        <ItemTemplate>
                            <asp:ListBox runat="server" ID="lbRel3" CssClass="lb"></asp:ListBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Project Managers" ItemStyle-CssClass="tdlb">
                        <ItemTemplate>
                            <asp:ListBox runat="server" ID="lbRel4" CssClass="lb"></asp:ListBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </div>
</asp:Content>