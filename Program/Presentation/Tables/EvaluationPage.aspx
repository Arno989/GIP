<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage2.0.Master" AutoEventWireup="true" CodeBehind="EvaluationPage.aspx.cs" Inherits="Presentation.Site.EvaluationPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Evaluations</title>
</asp:Content>

<asp:Content ID="Form" ContentPlaceHolderID="Form" runat="server">
    <div class="view-page">
    <div class="form">
        <h2>Evaluations</h2>
        <hr />
        <div class="gridview">
            <asp:GridView ID="GridView" runat="server" AllowSorting="True" OnSorting="Sort" onrowdatabound="Gridview_RowDataBound" AutoGenerateColumns="False" DataKeyNames="Evaluation_ID" CssClass="gv">
                <Columns>
                    <asp:TemplateField HeaderText="Type">
                        <ItemTemplate>
                            <asp:Label ID="lbType" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lbName" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date"/>
                    <asp:BoundField DataField="Feedback" HeaderText="Feedback" SortExpression="Feedback"/>
                    <asp:BoundField DataField="Accuracy" HeaderText="Accuracy" SortExpression="Accuracy"/>
                    <asp:BoundField DataField="Quality" HeaderText="Quality" SortExpression="Quality"/>
                    <asp:BoundField DataField="Evaluation_txt" HeaderText="Evaluation" SortExpression="Evaluation_Text"/>
                    <asp:BoundField DataField="Label" HeaderText="Label" SortExpression="Label"/>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </div>
</asp:Content>