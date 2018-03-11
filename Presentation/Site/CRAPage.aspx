<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSite.Master" AutoEventWireup="true" CodeBehind="CRAPage.aspx.cs" Inherits="Presentation.Site.CRAPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>CRA's</title>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<div class="headLeft"><p class="uppercase">CRA's</p></div>
	<div class="headRight"><a href="../SiteEdit/CRAPageEdit.aspx"><i class="material-icons">create</i></a></div>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
	<asp:GridView ID="GridView" runat="server">
	</asp:GridView>
</asp:Content>