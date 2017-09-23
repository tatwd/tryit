<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sign Page</title>
    <link href="~/css/sign-container.css" rel="stylesheet" />
</head>
<body>
    <form id="signForm" runat="server">
    <div>
        <h2>Hello Sign Up Page!</h2>

        <div class="container">
            <div class="title">注册</div>
            
            <div class="input">
                
                <div class="name">
                    <asp:TextBox ID="nameBox" runat="server" placeholder="用户名"></asp:TextBox>
                </div>
                
                <div class="email">
                    <asp:TextBox ID="emailBox" runat="server" TextMode="Email" placeholder="邮箱"></asp:TextBox>
                    <!-- 邮箱验证 -->
                    <asp:RegularExpressionValidator ID="checkEmail" CssClass="validator" runat="server" 
                        ControlToValidate="emailBox" ErrorMessage="请输入正确的邮箱" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                    </asp:RegularExpressionValidator>
                </div>
                
                <div class="phone">
                    <asp:TextBox ID="phoneBox" runat="server" TextMode="Phone" placeholder="手机号"></asp:TextBox>
                    <!-- 手机号码验证 -->
                    <asp:RegularExpressionValidator ID="checkPhone" CssClass="validator" runat="server" 
                        ControlToValidate="phoneBox" ErrorMessage="请输入正确的手机号" 
                        ValidationExpression="^1(3|4|5|7|8)\d{9}$">
                    </asp:RegularExpressionValidator>
                </div>
                
                <div class="passwd">
                    <asp:TextBox ID="passwdBox" runat="server" TextMode="Password" placeholder="密码（不少于6位）"></asp:TextBox>
                </div>
                
                <div class="confirm-passwd">
                    <asp:TextBox ID="confirmPasswdBox" runat="server" TextMode="Password" placeholder="确认密码"></asp:TextBox>
                </div>
            </div>
            <div class="sign">
                <asp:Button ID="signUpBtn" runat="server" Text="提交" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
