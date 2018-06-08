﻿<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSiteEdit.Master" AutoEventWireup="true" CodeBehind="ContractPageEdit.aspx.cs" Inherits="Presentation.SiteEdit.ContractPageEdit" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Edit Client Contracts</title>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<div class="headEditLeft"><p class="uppercase">Edit Client Contracts</p></div>
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
                <asp:TableHeaderCell>Legal Country</asp:TableHeaderCell>
                <asp:TableHeaderCell>Fee</asp:TableHeaderCell>
                <asp:TableHeaderCell>Start Date</asp:TableHeaderCell>
                <asp:TableHeaderCell>End Date</asp:TableHeaderCell>
                <asp:TableHeaderCell>Project</asp:TableHeaderCell>
                <asp:TableHeaderCell>Client</asp:TableHeaderCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit00"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:TextBox runat="server" CssClass="textboxEdit" ID="tbEdit01"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <input type="date" name="tbEdit02" data-data-inline-picker="true"/>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <input class="datepicker" type="date" name="tbEdit03" data-data-inline-picker="true"/>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit00" AppendDataBoundItems = "true">
                        <asp:ListItem Selected="True" Text="Select a Project" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit01" AppendDataBoundItems = "true">
                        <asp:ListItem Selected="True" Text="Select a client" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow CssClass="rowEdit" runat="server">
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
                    <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit10" AppendDataBoundItems = "true">
                        <asp:ListItem Selected="True" Text="Select a Project" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit11" AppendDataBoundItems = "true">
                        <asp:ListItem Selected="True" Text="Select a client" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
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
                    <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit20" AppendDataBoundItems = "true">
                        <asp:ListItem Selected="True" Text="Select a Project" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit21" AppendDataBoundItems = "true">
                        <asp:ListItem Selected="True" Text="Select a client" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
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
                    <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit30" AppendDataBoundItems = "true">
                        <asp:ListItem Selected="True" Text="Select a Project" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit31" AppendDataBoundItems = "true">
                        <asp:ListItem Selected="True" Text="Select a client" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
			</asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
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
                    <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit40" AppendDataBoundItems = "true">
                        <asp:ListItem Selected="True" Text="Select a Project" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit41" AppendDataBoundItems = "true">
                        <asp:ListItem Selected="True" Text="Select a client" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
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
                    <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit50" AppendDataBoundItems = "true">
                        <asp:ListItem Selected="True" Text="Select a Project" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit51" AppendDataBoundItems = "true">
                        <asp:ListItem Selected="True" Text="Select a client" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
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
                    <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit60" AppendDataBoundItems = "true">
                        <asp:ListItem Selected="True" Text="Select a Project" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit61" AppendDataBoundItems = "true">
                        <asp:ListItem Selected="True" Text="Select a client" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
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
                    <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit70" AppendDataBoundItems = "true">
                        <asp:ListItem Selected="True" Text="Select a Project" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit71" AppendDataBoundItems = "true">
                        <asp:ListItem Selected="True" Text="Select a client" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
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
                    <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit80" AppendDataBoundItems = "true">
                        <asp:ListItem Selected="True" Text="Select a Project" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit81" AppendDataBoundItems = "true">
                        <asp:ListItem Selected="True" Text="Select a client" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
			<asp:TableRow CssClass="rowEdit" runat="server">
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
                    <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit90" AppendDataBoundItems = "true">
                        <asp:ListItem Selected="True" Text="Select a Project" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="cellEdit">
                    <asp:DropDownList runat="server" CssClass="dropdownEdit" ID="ddEdit91" AppendDataBoundItems = "true">
                        <asp:ListItem Selected="True" Text="Select a client" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
		</asp:Table>
    </div>
</asp:Content>
