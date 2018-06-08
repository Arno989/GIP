<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSiteEdit.Master" AutoEventWireup="true" CodeBehind="ProjectPageEdit.aspx.cs" Inherits="Presentation.SiteEdit.ProjectPageEdit" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Edit Projects</title>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<div class="headEditLeft"><p class="uppercase">Edit Projects</p></div>
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
                <asp:TableHeaderCell>Title</asp:TableHeaderCell>
                <asp:TableHeaderCell>Start Date</asp:TableHeaderCell>
                <asp:TableHeaderCell>End Date</asp:TableHeaderCell>
                <asp:TableHeaderCell>CRA's</asp:TableHeaderCell>
                <asp:TableHeaderCell>Doctors</asp:TableHeaderCell>
                <asp:TableHeaderCell>Hospitals</asp:TableHeaderCell>
                <asp:TableHeaderCell>Project Managers</asp:TableHeaderCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit00"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit01" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit02" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit00" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit01" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit02" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit03" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit10"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit11" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit12" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit10" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit11" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit12" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit13" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit20"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit21" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit22" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit20" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit21" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit22" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit23" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit30"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit31" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit32" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit30" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit31" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit32" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit33" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
			</asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit40"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit41" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit42" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit40" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit41" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit42" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit43" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit50"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit51" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit52" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit50" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit51" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit52" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit53" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit60"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit61" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit62" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit60" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit61" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit62" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit63" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit70"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit71" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit72" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit70" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit71" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit72" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit73" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit80"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit81" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit82" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit80" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit81" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit82" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit83" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit90"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit91" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit92" TextMode="Date"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit90" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit91" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit92" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbEdit93" AppendDataBoundItems="true" CssClass="listboxEdit" AutoPostBack="true">
                    </asp:ListBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</asp:Content>