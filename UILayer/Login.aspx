<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Style/style.css" media="screen" type="text/css" />
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="Scripts/index.js" type="text/javascript"></script>
    <title></title>
    <script type="text/javascript">
        function pop(div) {
            document.getElementById(div).style.display = 'block';
        }
        function hide(div) {
            document.getElementById(div).style.display = 'none';
            $("#txtUserName").parent().next(".validation").remove();
        }
        //To detect escape button
        document.onkeydown = function (evt) {
            evt = evt || window.event;
            if (evt.keyCode == 27) {
                hide('popDiv');
            }
        };
    </script>
</head>
<body>
    <span href="#" class="button" id="toggle-login">Log in</span>
    <div id="login">
        <div id="triangle">
        </div>
        <h1>
            Log in</h1>
        <form id="form1" runat="server">
        <input id="hdnFromEmail" type="hidden" runat="server" />
        <asp:TextBox ID="txtEmail" runat="server" placeholder="UserName" CssClass="txtBox"
            MaxLength="100"></asp:TextBox>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"
            MaxLength="8" CssClass="txtBox"></asp:TextBox>
        <asp:Button ID="btnLogin" runat="server" Text="Log in" CssClass="loginButton" OnClick="btnLogin_Click" />
        <div class="text-center">
            <asp:Label ID="lblMessage" runat="server" CssClass="validation"></asp:Label>
        </div>
        <div class="text-center">
            <a href="#" tabindex="5" onclick="pop('popDiv')" class="forgot-password">Forgot Password?</a>
        </div>
        <div id="popDiv" class="modal">
            <!-- Modal content -->
            <div class="modal-content">
                <span class="close" onclick="hide('popDiv');">&times;</span>
                <h1>
                    Forgot Password?</h1>
                <div>
                    <span>Enter User Name:</span>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="forgetTextBox" placeholder="UserName"
                        ClientIDMode="Static" MaxLength="100"></asp:TextBox></div>
                <input id="btnResetPassword" type="button" value="E-Mail My Password" class="btnForgetPassword" />
            </div>
        </form>
    </div>
</body>
</html>
