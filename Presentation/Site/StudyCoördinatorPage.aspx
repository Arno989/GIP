<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSite.Master" AutoEventWireup="true" CodeBehind="StudyCoördinatorPage.aspx.cs" Inherits="Presentation.Site.StudyCoördinatorPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Study Coördinators</title>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<div class="headLeft"><p class="uppercase">Study Coördinators</p></div>
	<div class="headRight"><a href="../SiteEdit/StudyCoördinatorPageEdit.aspx"><i class="material-icons">create</i></a></div>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
	<asp:GridView ID="GridView" runat="server">
	</asp:GridView>
</asp:Content>