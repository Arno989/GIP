<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Presentation.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login CliniresearchDB</title>
    <link rel="stylesheet" href="~/LoginStyleSheet.css" runat="server"/>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
	<link rel="icon" type="image/png" sizes="32x32" href="images/favicon-32x32.png"/>
    
</head>
<body>
<div class="login-page">
  <form runat="server" class="form">
    <div class="login-form">
      <asp:TextBox runat="server" ID="tbUsername" placeholder="username" CssClass="input"></asp:TextBox>
      <asp:TextBox runat="server" ID="tbPassword" placeholder="password" TextMode="Password" CssClass="input"></asp:TextBox>
      <asp:Button runat="server" ID="btnLogin" Text="Login" OnClick="BtnLogin_Click" CssClass="button"/>
      <asp:Label runat="server" ID="lbError" Visible="false" CssClass="error"></asp:Label>
      <p class="message">Not registered? <a href="/Register.aspx">Create an account</a></p>
    </div>
  </form>
</div>
</body>
</html>
