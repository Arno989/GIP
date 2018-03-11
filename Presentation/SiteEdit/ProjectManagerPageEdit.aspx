<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSiteEdit.Master" AutoEventWireup="true" CodeBehind="ProjectManagerPageEdit.aspx.cs" Inherits="Presentation.SiteEdit.ProjectManagerPageEdit" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Edit Project Managers</title>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<div class="headEditLeft"><p class="uppercase">Edit Project Managers</p></div>
	<div class="headEditRight">
			<asp:Button ID="btnSave" runat="server" Text="Save" BackColor="White" CssClass="editButton" BorderColor="Black" BorderStyle="Solid" BorderWidth="0.1px" ForeColor="Black" Width="81px" OnClick="btnSave_Click" />
			<asp:Button ID="btnSaveAndExit" runat="server" Text="Save & Exit" BackColor="White" CssClass="editButton" BorderColor="Black" BorderStyle="Solid" BorderWidth="0.1px" ForeColor="Black" Width="156px" OnClick="btnSaveAndExit_Click" />
			<asp:Button ID="btnExit" runat="server" Text="Exit" BackColor="White" CssClass="editButton" BorderColor="Black" BorderStyle="Solid" BorderWidth="0.1px" ForeColor="Black" Width="81px" OnClick="btnExit_Click" />
		</div>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
    <div>
        <asp:Table ID="Table" runat="server" CssClass="tableEdit">
            <asp:TableRow runat="server" ID="row0">
                <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>CV</asp:TableHeaderCell>
                <asp:TableHeaderCell>E mail</asp:TableHeaderCell>
                <asp:TableHeaderCell>Phone 1</asp:TableHeaderCell>
                <asp:TableHeaderCell>Phone 2</asp:TableHeaderCell>
            </asp:TableRow>
						<asp:TableRow runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit00"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit01"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit02"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit03"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit04"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit10"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit11"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit12"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit13"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit14"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
						<asp:TableRow runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit20"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit21"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit22"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit23"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit24"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
						<asp:TableRow runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit30"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit31"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit32"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit33"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit34"></asp:TextBox>
                </asp:TableCell>
						</asp:TableRow>
						<asp:TableRow runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit40"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit41"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit42"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit43"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit44"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
						<asp:TableRow runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit50"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit51"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit52"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit53"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit54"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
						<asp:TableRow runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit60"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit61"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit62"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit63"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit64"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
						<asp:TableRow runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit70"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit71"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit72"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit73"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit74"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
						<asp:TableRow runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit80"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit81"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit82"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit83"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit84"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
						<asp:TableRow runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit90"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit91"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit92"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit93"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit94"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
				</asp:Table>
    </div>
</asp:Content>