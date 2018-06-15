<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="Presentation.Site.ProfilePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register CliniresearchDB</title>
    <link rel="stylesheet" href="~/LoginStyleSheet.css" runat="server"/>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
	<link rel="icon" type="image/png" sizes="32x32" href="images/favicon-32x32.png"/>
    
</head>
<body>
<div class="login-page">
    <div class="edit">
  <form runat="server" class="form">
    <div class="edit-form">
        <h1>Account details</h1>
      <asp:TextBox runat="server" ID="tbUsername" placeholder="username" CssClass="input"></asp:TextBox>
      <asp:Label runat="server" ID="lbError" Visible="false" CssClass="error"></asp:Label>
      <asp:TextBox runat="server" ID="tbEmail" placeholder="email adress" CssClass="input"></asp:TextBox>
      <asp:TextBox runat="server" ID="tbPasswordOld" placeholder="old password" TextMode="Password" CssClass="input"></asp:TextBox>
      <asp:TextBox runat="server" ID="tbPasswordNew1" placeholder="new password" TextMode="Password" CssClass="input"></asp:TextBox>
      <asp:TextBox runat="server" ID="tbPasswordNew2" placeholder="new password" TextMode="Password" CssClass="input"></asp:TextBox>
      <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="buttonLeft"/>
      <asp:Button runat="server" ID="btnExit" Text="Exit" CssClass="buttonRight"/>
      <asp:LinkButton runat="server" ID="lnkDelete" Text="Delete account" CssClass="linkButton"></asp:LinkButton>
    </div>
  </form>
        </div>
</div>
</body>
</html>
