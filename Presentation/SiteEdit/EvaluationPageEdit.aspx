<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSiteEdit.Master" AutoEventWireup="true" CodeBehind="EvaluationPageEdit.aspx.cs" Inherits="Presentation.SiteEdit.EvaluationPageEdit" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Edit Evaluations</title>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<div class="headEditLeft"><p class="uppercase">Edit Evaluations</p></div>
	<div class="headEditRight">
			<asp:Button ID="btnSave" runat="server" autopostback="true" Text="Save" CssClass="editButton" OnClick="BtnSave_Click" />
			<asp:Button ID="btnSaveAndExit" runat="server" autopostback="true" Text="Save & Exit" CssClass="editButton" OnClick="BtnSaveAndExit_Click" />
			<asp:Button ID="btnExit" runat="server" autopostback="true" Text="Exit" CssClass="editButton" OnClick="BtnExit_Click" />
		</div>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
    <div>
        <asp:Table ID="Table" runat="server" CssClass="tableEdit">
            <asp:TableRow runat="server" ID="row0">
                <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                <asp:TableHeaderCell>Feedback</asp:TableHeaderCell>
                <asp:TableHeaderCell>Accuracy</asp:TableHeaderCell>
                <asp:TableHeaderCell>Quality</asp:TableHeaderCell>
                <asp:TableHeaderCell>Evaluation Text</asp:TableHeaderCell>
                <asp:TableHeaderCell>Label</asp:TableHeaderCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit00" AppendDataBoundItems = "true">
                    <asp:ListItem Selected="True" Text="Select a person" Value=""></asp:ListItem>
                </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="dateEdit" ID="tbEdit00" TextMode="Date"></asp:TextBox>
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
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="colorEdit" ID="tbEdit05" TextMode="Color"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit10" AppendDataBoundItems = "true">
                    <asp:ListItem Selected="True" Text="Select a person" Value=""></asp:ListItem>
                </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="dateEdit" ID="tbEdit10" TextMode="Date"></asp:TextBox>
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
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="colorEdit" ID="tbEdit15" TextMode="Color"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit20" AppendDataBoundItems = "true">
                    <asp:ListItem Selected="True" Text="Select a person" Value=""></asp:ListItem>
                </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="dateEdit" ID="tbEdit20" TextMode="Date"></asp:TextBox>
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
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="colorEdit" ID="tbEdit25" TextMode="Color"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit30" AppendDataBoundItems = "true">
                    <asp:ListItem Selected="True" Text="Select a person" Value=""></asp:ListItem>
                </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="dateEdit" ID="tbEdit30" TextMode="Date"></asp:TextBox>
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
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="colorEdit" ID="tbEdit35" TextMode="Color"></asp:TextBox>
                </asp:TableCell>
			</asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit40" AppendDataBoundItems = "true">
                    <asp:ListItem Selected="True" Text="Select a person" Value=""></asp:ListItem>
                </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="dateEdit" ID="tbEdit40" TextMode="Date"></asp:TextBox>
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
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="colorEdit" ID="tbEdit45" TextMode="Color"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit50" AppendDataBoundItems = "true">
                    <asp:ListItem Selected="True" Text="Select a person" Value=""></asp:ListItem>
                </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="dateEdit" ID="tbEdit50" TextMode="Date"></asp:TextBox>
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
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="colorEdit" ID="tbEdit55" TextMode="Color"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit60" AppendDataBoundItems = "true">
                    <asp:ListItem Selected="True" Text="Select a person" Value=""></asp:ListItem>
                </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="dateEdit" ID="tbEdit60" TextMode="Date"></asp:TextBox>
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
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="colorEdit" ID="tbEdit65" TextMode="Color"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit70" AppendDataBoundItems = "true">
                    <asp:ListItem Selected="True" Text="Select a person" Value=""></asp:ListItem>
                </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="dateEdit" ID="tbEdit70" TextMode="Date"></asp:TextBox>
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
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="colorEdit" ID="tbEdit75" TextMode="Color"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit80" AppendDataBoundItems = "true">
                    <asp:ListItem Selected="True" Text="Select a person" Value=""></asp:ListItem>
                </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="dateEdit" ID="tbEdit80" TextMode="Date"></asp:TextBox>
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
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="colorEdit" ID="tbEdit85" TextMode="Color"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit90" AppendDataBoundItems = "true">
                    <asp:ListItem Selected="True" Text="Select a person" Value=""></asp:ListItem>
                </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="dateEdit" ID="tbEdit90" TextMode="Date"></asp:TextBox>
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
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="colorEdit" ID="tbEdit95" TextMode="Color"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</asp:Content>