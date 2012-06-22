<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LibraryPro.Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" href="css/Site.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery-1.6.2.min.js"></script>
    <script type ="text/javascript">
//            $().ready(function () {
//                $("#form1").validate({
//                    rules: {
//                        txtUsername: "required"
//                    },
//                    message: {
//                        txtUsername: "Please Enter Uer Name"
//                    }
//                });
//            });
    </script>
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
    </style>
</head>
<body>
<%
if (!BLibraryPro.MISC.IsServerLive())
{
    Response.Write("<div class = 'msg_box'><h2>Server Connection is not avilable.</h2><br> Contact your administrator</div>");
    Response.End();
}
%>
    <form id="form1" runat="server" clientidmode="Static">
    <div  style=" margin-top:250px;"> 
    <center>
    <strong> Username and Password to LogIn</strong><br /><br />    
        <table align="center">
            <tr>
                <td>Username</td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td colspan= "2" class="style1"><asp:Label ID="lblStatus" runat ="server" Text="" CssClass="error_msg"></asp:Label>  </td>
            </tr>
           <tr>
                
                <td>
                    <asp:Button ID="btnLogin" runat="server" Text="Log In" 
                        onclick="btnLogin_Click" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnReset" runat="server" Text="Reset" />
                </td>
           </tr>
        </table>
    </center>
    </div>
    </form>
</body>
</html>
