<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSite.Master" AutoEventWireup="true" CodeBehind="ProjectManagerPage.aspx.cs" Inherits="Presentation.Site.ProjectManagerPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Project Managers</title>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<div class="headLeft"><p class="uppercase">Project Managers</p></div>
	<div class="headRight"><a href="../SiteEdit/ProjectManagerPageEdit.aspx"><i class="material-icons">create</i></a></div>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
	<asp:GridView ID="GridView" runat="server">
	</asp:GridView>
</asp:Content>