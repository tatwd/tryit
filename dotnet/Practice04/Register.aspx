<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Register</title>
    <style>
        #form1 {
            text-align: center;
        }

        .reg-box {
            display: inline-block;
            border: 3px solid #ddd;
            padding: 15px;
            border-radius: 3px;
        }

        .username, .password, .reg-email, .confirm-passwd{
            padding: 8px 15px;
            position: relative;
            border: 1px solid #ddd;
            margin-bottom: 15px;
            top: 0px;
            left: 0px;
            width: 159px;
        }

        .reg-btn {
            padding: 8px 15px;
            border-radius: 3px;
            background-color: #ddd;
            cursor: pointer;

        }

        #user, #passwd, #email, #rePasswd{
            border: 0;
            outline: 0;
            width: 100%;
        }

        .validator {
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
        <h2>Register</h2>
        <div class="reg-box">
            <div class="username">
                <asp:TextBox ID="user" runat="server" placeholder="用户名"></asp:TextBox>
                <asp:RequiredFieldValidator ID="checkUser" CssClass="validator" runat="server" ControlToValidate="user" ErrorMessage="请输入用户名"></asp:RequiredFieldValidator>
            </div>
            <div class="reg-email">
                <asp:TextBox ID="email" runat="server" placeholder="邮箱"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="validator" runat="server" ControlToValidate="email" ErrorMessage="请输入用户名"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="checkEmail" CssClass="validator" runat="server" ControlToValidate="email" ErrorMessage="请输入正确的邮箱" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
            <div class="password">
                <asp:TextBox ID="passwd" runat="server" placeholder="密码（不少于6位）" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="checkPasswd" CssClass="validator" runat="server" ControlToValidate="passwd" ErrorMessage="请输入密码"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="checkPasswdLength" CssClass="validator" runat="server" ControlToValidate="passwd" ErrorMessage="不少于6位" ClientValidationFunction="checkLength"></asp:CustomValidator>
            </div>
            <div class="confirm-passwd">
                    <asp:TextBox ID="rePasswd" runat="server" TextMode="Password" placeholder="确认密码"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="notNullConfirm" CssClass="validator" runat="server" ControlToValidate="rePasswd" ErrorMessage="请确认密码"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="confirmPasswd" CssClass="validator" runat="server" ControlToCompare="passwd" ControlToValidate="rePasswd" ErrorMessage="密码输入不一致"></asp:CompareValidator>
                </div>
            <div class="reg-btn">
                <asp:Button ID="Btn" runat="server" Text="注册" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
