<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSite.Master" AutoEventWireup="true" CodeBehind="DepartmentPage.aspx.cs" Inherits="Presentation.Site.DepartmentPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Departments</title>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<div class="headLeft"><p class="uppercase">Departments</p></div>
	<div class="headRight"><a href="../SiteEdit/DepartmentPageEdit.aspx"><i class="material-icons">create</i></a></div>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
	<asp:GridView ID="GridView" runat="server">
	</asp:GridView>
</asp:Content>