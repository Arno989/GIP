<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="Presentation.Site.ProfilePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register CliniresearchDB</title>
    <link rel="stylesheet/less" type="text/css" href="/OneLessThingToWorryAbout.less" runat="server"/>
    <script src="//cdnjs.cloudflare.com/ajax/libs/less.js/2.5.3/less.min.js"></script>
	<link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
	<link rel="icon" type="image/png" sizes="32x32" href="images/favicon-32x32.png"/>
    
</head>
<body>
<div class="login-page">
    <div class="edit">
  <form runat="server" class="form">
    <div class="edit-form">
        <h1>Account details</h1>
        <asp:TextBox runat="server" ID="tbUsername" placeholder="username" CssClass="input" OnTextChanged="tb_TextChanged"></asp:TextBox>
        <asp:Label runat="server" ID="lbErrorUsername" Visible="true" CssClass="error"></asp:Label>
        <asp:TextBox runat="server" ID="tbEmail" placeholder="email adress" CssClass="input" OnTextChanged="tb_TextChanged"></asp:TextBox>
        <asp:TextBox runat="server" ID="tbPasswordOld" AutoCompleteType="None" placeholder="old password" TextMode="Password" CssClass="input" OnTextChanged="tb_TextChanged"></asp:TextBox>
        <asp:TextBox runat="server" ID="tbPasswordNew1" placeholder="new password" TextMode="Password" CssClass="input" OnTextChanged="tb_TextChanged"></asp:TextBox>
        <asp:Label runat="server" ID="lbErrorPassword" Visible="false" CssClass="error"></asp:Label>
        <asp:TextBox runat="server" ID="tbPasswordNew2" placeholder="new password" TextMode="Password" CssClass="input" OnTextChanged="tb_TextChanged"></asp:TextBox>
        <asp:TextBox runat="server" ID="tbAccountType" ReadOnly="true" CssClass="label"></asp:TextBox>
        <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="buttonLeft" OnClick="btnSave_Click"/>
        <asp:Button runat="server" ID="btnExit" Text="Exit" CssClass="buttonRight" OnClick="btnExit_Click"/>
        <asp:LinkButton runat="server" ID="lnkDelete" Text="Delete account" CssClass="linkButton" OnClick="lnkDelete_Click"></asp:LinkButton>
    </div>
  </form>
 </div>
</div>
</body>
</html>
