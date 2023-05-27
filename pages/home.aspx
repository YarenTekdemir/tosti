<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="tostiş.pages.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">Safety</div>
    <div id="testdesc1">
            <p> 
                T1217 Browser Bookmark Discovery:
                Adversaries may enumerate browser bookmarks to learn more about compromised hosts. Browser bookmarks may reveal personal information about users (ex: banking sites, interests, social media, etc.) as well as details about internal network resources such as servers, tools/dashboards, or other related infrastructure.<br />
                T1056 Input Capture:
                Adversaries may use methods of capturing user input to obtain credentials or collect information. During normal system usage, users often provide credentials to various different locations, such as login pages/portals or system dialog boxes. Input capture mechanisms may be transparent to the user (e.g. Credential API Hooking) or rely on deceiving the user into providing input into what they believe to be a genuine service (e.g. Web Portal Capture).
            </p>
        </div>
     <table id="atttable">
            <thead>
                <tr>
                    <th>Code</th>
                    <th>Description</th>
                    <th></th> 
                </tr>
            </thead>
                <tbody> 
            <tr>
                <td>T1217</td>
                <td>Browser Bookmark Discovery</td>
                <td><asp:Button ID="btndownload" runat="server" Text="Download" OnClick="btndownload_Click" /></td>
                <td><asp:Button ID="btnrun" runat="server" Text="Run" OnClick="btnrun_Click" /></td>

                
            </tr>
            <tr>
                <td>T1056</td>
                <td>Input Capture</td>
                <td><asp:Button ID="btndownload1" runat="server" Text="Download" OnClick="btndownload1_Click"  /></td>                
                <td><asp:Button ID="btnrun1" runat="server" Text="Run" OnClick="btnrun1_Click" /></td>                
            </tr>
            </tbody>
           
    </table>
        <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red" BackColor="#182137"></asp:Label>

        <div id="navigation" >
            <ul>
                <li><a href="home.aspx">Home</a></li>
                <li><a href="Settings.aspx">Setting</a></li>
                <li><a href="profile.aspx">Profile</a></li>
            </ul>
        </div>
    </form>
    
</body>
</html>
