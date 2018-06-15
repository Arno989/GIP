<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSite.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Presentation.Site.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
    <p>
        PROFILE
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="server">
    <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
    <asp:Label ID="lblUserText" runat="server" Text="User not found "></asp:Label>
    <asp:TextBox ID="tbUserChange" runat="server" Text="Change username" Visible="false"></asp:TextBox>

    <asp:Label ID="lblEmail" runat="server" Text="E-mail: "></asp:Label>
    <asp:Label ID="lblEmailText" runat="server" Text="E-mail not found"></asp:Label>
    <asp:TextBox ID="tbEmailChange" runat="server" Text="Change e-mail" Visible="false"></asp:TextBox>

    <asp:Label ID="lblType" runat="server" Text="Account type: "></asp:Label>
    <asp:Label ID="lbltypeText" runat="server" Text="Account type not found "></asp:Label>

    <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
    <asp:Label ID="lblPasswordText" runat="server" Text="Password not found" TextMode="Password"></asp:Label>
    <asp:TextBox ID="tbPasswordChangeOld" runat="server" Text="Old password" Visible="false"></asp:TextBox>
    <asp:TextBox ID="tbPasswordChange1" runat="server" Text="Change password" Visible="false"></asp:TextBox>
    <asp:TextBox ID="tbPasswordChange2" runat="server" Text="Repaet password" Visible="false"></asp:TextBox>

    <asp:Button ID="btnChange" runat="server" Text="Change account data" OnClick="btnChange_Click" />
    <asp:Button ID="btnChangeSave" runat="server" Text="Save changes" OnClick="btnChangeSave_Click" Visible="false" />
    <asp:Button ID="btnChangePassword" runat="server" Text="Change account password" OnClick="btnChangePassword_Click" />
    <asp:Button ID="btnChangePasswordSave" runat="server" Text="Save changes" OnClick="btnChangePasswordSave_Click" Visible="false" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete my account" OnClick="btnDelete_Click" />
</asp:Content>
