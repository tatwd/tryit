<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomValidator.aspx.cs" Inherits="CustomValidator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>
        var isPrim = function (source, arguments) {
            var r = Math.sqrt(arguments.Value) | 0; // 取整

            for (var i = 2; i <= r; i++) {
                if (arguments.Value % i == 0) {
                    return arguments.IsValid = false;
                }
            }
            return arguments.IsValid = true;
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="不是素数" ControlToValidate="TextBox1" Display="Dynamic" ClientValidationFunction="isPrim" EnableClientScript="true"></asp:CustomValidator>
        <asp:Button ID="Button1" runat="server" Text="验证素数" />
    
    </div>
    </form>
</body>
</html>
