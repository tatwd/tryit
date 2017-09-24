<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompareValidator.aspx.cs" Inherits="CompareValidator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="输入2001年9月1日以后的日期" ControlToValidate="TextBox1" Operator="GreaterThan" Type="Date" Display="Dynamic" ValueToCompare="2001-9-1"></asp:CompareValidator>
        <asp:Button ID="Button1" runat="server" Text="Button" />
    
    </div>
    </form>
</body>
</html>
