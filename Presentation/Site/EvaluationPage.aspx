<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSite.Master" AutoEventWireup="true" CodeBehind="EvaluationPage.aspx.cs" Inherits="Presentation.Site.EvaluationPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Evaluations</title>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<div class="headLeft"><p class="uppercase">Evaluations</p></div>
	<div class="headRight"><a href="../SiteEdit/EvaluationPageEdit.aspx"><i class="material-icons">create</i></a></div>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
	<asp:GridView ID="GridView" runat="server">
	</asp:GridView>
</asp:Content>