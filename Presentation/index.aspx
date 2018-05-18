<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSite.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Presentation.Site.HomeSite" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Home</title>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<p class="uppercase">Home</p>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
    <asp:Table runat="server" CssClass="homeTable">
        <asp:TableRow CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:Button runat="server" autopostback="true" CssClass="homeImageButton" Text="CRA" OnClick="ButtonCRA_Click"/>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <asp:Button runat="server" autopostback="true" CssClass="homeImageButton" Text="Client" OnClick="ButtonClient_Click"/>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <asp:Button runat="server" autopostback="true" CssClass="homeImageButton" Text="Client Contract" OnClick="ButtonClientContract_Click"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:Button runat="server" autopostback="true" CssClass="homeImageButton" Text="Department" OnClick="ButtonDepartment_Click"/>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <asp:Button runat="server" autopostback="true" CssClass="homeImageButton" Text="Doctor" OnClick="ButtonDoctor_Click"/>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <asp:Button runat="server" autopostback="true" CssClass="homeImageButton" Text="Evaluation" OnClick="ButtonEvaluation_Click"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:Button runat="server" autopostback="true" CssClass="homeImageButton" Text="Hospital" OnClick="ButtonHospital_Click"/>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <asp:Button runat="server" autopostback="true" CssClass="homeImageButton" Text="Project Manager" OnClick="ButtonProjectManager_Click"/>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <asp:Button runat="server" autopostback="true" CssClass="homeImageButton" Text="Project" OnClick="ButtonProject_Click"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow CssClass="homeRow">
            <asp:TableCell CssClass="homeCell"></asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <asp:Button runat="server" autopostback="true" CssClass="homeImageButton" Text="Study Coordinator" OnClick="ButtonStudyCoordinator_Click"/>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>