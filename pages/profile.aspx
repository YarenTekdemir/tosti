<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="tostiş.pages.profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="StyleSheet.css">

</head>
<body>
     <div class="header"> SAFETY  </div>
    <form id="form1" runat="server">

        <div class="container" style="width:15em; float:right; background-color:#054293">                         
           <asp:Label ID="lbluser" runat="server" Text="" ></asp:Label>
           <asp:Label ID="lblusers" runat="server" Text="" ></asp:Label>
           
           <br />
           


           <asp:Label ID="lblmail" runat="server" Text="" ></asp:Label>
           

           <br />
           
       </div>
        <br />
        <br />
        <br />
         <asp:DataList ID="testdata" runat="server" DataSourceID="SqlTestData" BackColor="#054293" ForeColor="White">
        <ItemTemplate>
            
            <asp:Label  ID="test_idLabel" runat="server" Text='<%# Eval("test_id") %>'></asp:Label>
            <br />
            
            <asp:Label ID="test_descLabel" runat="server" Text='<%# Eval("test_desc") %>'></asp:Label>
            <br />
            <br />
        </ItemTemplate>
        </asp:DataList>
        <div id="btngroup1">
            <asp:Button Visible="false" ID="btnread1" runat="server" Text="Result" OnClick="btnread1_Click"  />
            <br />
        <asp:Button Visible="false"  ID="btnread2" runat="server" Text="Result" OnClick="btnread2_Click" />
        </div>

        
    
    
        <asp:SqlDataSource ID="SqlTestData" runat="server" ConnectionString="<%$ ConnectionStrings:WEBConnectionString %>" SelectCommand="SELECT DISTINCT [test_id], [test_desc] FROM [USED_TESTS] ORDER BY [test_desc]"></asp:SqlDataSource>
           

       <div style="margin-top:18.5em" id="navigation" >
           <ul>
                <li><a href="home.aspx">Home</a></li>
                <li><a href="Settings.aspx">Setting</a></li>
                <li><a href="profile.aspx">Profile</a></li>
                <li><a href="login.aspx">Logout</a></li>

            </ul>
        </div>
    </form>
</body>
</html>
