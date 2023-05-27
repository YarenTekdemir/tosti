<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="tostiş.login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Swimming</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css">
    
</head>
<body style="text-align:center">
     <div class="header">Safety</div>
    
    
    <form id="formlogin" runat="server">
        <div id="divlogin">
        <br />
         Email
        <br />
        <asp:TextBox ID="txtmail" runat="server"></asp:TextBox>
        <br />
        Password<br />
        <asp:TextBox ID="txtpass" runat="server" TextMode="Password" >
        </asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnloginpage" runat="server" Text="Login" OnClick="btnLogin_Click" />
        <br />
        <br />
        <br />
        
        <asp:HyperLink ID="btnsign"  runat="server" NavigateUrl="~/pages/signup.aspx"  >Sign up</asp:HyperLink>
        </div>
        <asp:Label ID="lblErrorMessage1" runat="server" Text="Incorrect User Credentials" ForeColor="Red"></asp:Label>

        


       
        
        
    </form>
</body>
</html>