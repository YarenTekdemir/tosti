<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="tostiş.signup" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link rel="stylesheet" type="text/css" href="StyleSheet.css">
</head>
<body style="text-align:center">
     <div class="header">Safety</div>
     
    <form id="formsign" runat="server">
        <br />
        Name
        <br />
        <asp:TextBox ID="txtname" runat="server" ></asp:TextBox>
        <br />
        <br />
        Surname
        <br />
        <asp:TextBox ID="txtsurname" runat="server"  >
        </asp:TextBox>
        <br />
        <br />
        Password
        <br />
        <asp:TextBox ID="txtpass" runat="server" >
        </asp:TextBox>
        <br />
        <asp:RegularExpressionValidator ID="validator" runat="server" ControlToValidate="txtpass" ErrorMessage="Between 6-12 characters. Including minimum 1 Upper-case and digit." ForeColor="Red" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,12}$" />
        <br />
        <br />
        Confirm Password
        <br />
        <asp:TextBox ID="txtpass2" runat="server">
        </asp:TextBox>
        <br />
        <asp:CompareValidator runat="server" ControlToCompare="txtpass" ControlToValidate="txtpass2"
                ErrorMessage="Passwords do not match." ForeColor="Red" Display="Dynamic">
            </asp:CompareValidator>
        
        <br />
        <br />
        Email
        <br />
        <asp:TextBox ID="txtmail" runat="server"  >
        </asp:TextBox>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtmail" runat="server" ErrorMessage="Invalid Type" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Button ID="btnsignup" runat="server" Text="Sign Up" OnClick="btnsignup_Click" />
        <br />
        <asp:Label ID="lblSuccess" runat="server" Text="Label" ForeColor="Green"></asp:Label>
        <br />
        <asp:Label ID="lblFailure" runat="server" Text="Label" ForeColor="Red"></asp:Label>
        
        
    </form>
    
</body>
</html>
