<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <style>
        #form1 {
            text-align: center;
        }

        .login-box {
            display: inline-block;
            border: 3px solid #ddd;
            padding: 15px;
            border-radius: 3px;
        }

        .username, .password {
            padding: 8px 15px;
            position: relative;
            border: 1px solid #ddd;
            margin-bottom: 15px;
            top: 0px;
            left: 0px;
            width: 159px;
        }

        .login-btn {
            padding: 8px 15px;
            border-radius: 3px;
            background-color: #ddd;
            cursor: pointer;

        }

        #user, #passwd {
            border: 0;
            outline: 0;
            width: 100%;
        }

        #checkUser, #checkPasswd , #checkPasswdLength{
            position: absolute;
            top: 10px;
            right: 8px;
            color: red;
            font-size: 12px;

        }

        #Btn {
            border: 0;
            background-color: #ddd;
            outline: 0;
            cursor: pointer;
        }
    </style>
    <script>
        var checkLength = function(source, args) {
            (args.Value.length < 6) ? args.IsValid = false : args.IsValid = true;
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Login</h2>
        <div class="login-box">
            <div class="username">
                <asp:TextBox ID="user" runat="server" placeholder="用户名"></asp:TextBox>
                <asp:RequiredFieldValidator ID="checkUser" runat="server" ControlToValidate="user" ErrorMessage="请输入用户名"></asp:RequiredFieldValidator>
            </div>
            <div class="password">
                <asp:TextBox ID="passwd" runat="server" placeholder="密码（不少于6位）" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="checkPasswd" runat="server" ControlToValidate="passwd" ErrorMessage="请输入密码"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="checkPasswdLength" runat="server" ControlToValidate="passwd" ErrorMessage="不少于6位" ClientValidationFunction="checkLength"></asp:CustomValidator>
            </div>
            <div class="login-btn">
                <asp:Button ID="Btn" runat="server" Text="登录" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
