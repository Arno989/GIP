<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSite.Master" AutoEventWireup="true" CodeBehind="EvaluationPage.aspx.cs" Inherits="Presentation.Site.EvaluationPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Evaluations</title>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<div class="headLeft"><p class="uppercase">Evaluations</p></div>
	<div class="headRight">
        <asp:LinkButton id="btnAdd" runat="server" OnClick="Add" ToolTip="Add one or more client(s)" ><i class="material-icons">add</i></asp:LinkButton>
        <asp:LinkButton id="btnEdit" runat="server" OnClick="Edit" Tooltip="Edit selected row(s)"><i class="material-icons">edit</i></asp:LinkButton>
        <asp:LinkButton id="btnDelete" runat="server" OnClick="Delete" ToolTip="Delete selected row(s)"><i class="material-icons">delete</i></asp:LinkButton>
	</div>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
    <asp:GridView ID="GridView" runat="server" AllowSorting="True" OnSorting="Sort" onrowdatabound="Gridview_RowDataBound" AutoGenerateColumns="False" DataKeyNames="Evaluation_ID" RowStyle-CssClass="gvtr">
        <Columns>
            <asp:TemplateField ShowHeader="false" HeaderStyle-Width="50px"  ItemStyle-CssClass="gvtd">
                <ItemTemplate>
                    <label class="container">
                        <asp:CheckBox ID="CheckBox" runat="server" />
                        <span class="checkmark"></span>
                    </label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type" HeaderStyle-ForeColor="Black" ItemStyle-CssClass="gvtd">
                <ItemTemplate>
                    <asp:Label ID="lbType" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name" HeaderStyle-ForeColor="Black" ItemStyle-CssClass="gvtd">
                <ItemTemplate>
                    <asp:Label ID="lbName" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" HeaderStyle-ForeColor="Black"  ItemStyle-CssClass="gvtd"/>
            <asp:BoundField DataField="Feedback" HeaderText="Feedback" SortExpression="Feedback" HeaderStyle-ForeColor="Black"  ItemStyle-CssClass="gvtd"/>
            <asp:BoundField DataField="Accuracy" HeaderText="Accuracy" SortExpression="Accuracy" HeaderStyle-ForeColor="Black"  ItemStyle-CssClass="gvtd"/>
            <asp:BoundField DataField="Quality" HeaderText="Quality" SortExpression="Quality" HeaderStyle-ForeColor="Black"  ItemStyle-CssClass="gvtd"/>
            <asp:BoundField DataField="Evaluation_txt" HeaderText="Evaluation" SortExpression="Evaluation_Text" HeaderStyle-ForeColor="Black"  ItemStyle-CssClass="gvtd"/>
            <asp:BoundField DataField="Label" HeaderText="Label" SortExpression="Label" HeaderStyle-ForeColor="Black"  ItemStyle-CssClass="gvtd"/>
        </Columns>
    </asp:GridView>
</asp:Content>