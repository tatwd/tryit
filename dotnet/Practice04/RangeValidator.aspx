<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RangeValidator.aspx.cs" Inherits="RangeValidator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        年龄：
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="年龄应在18~80之间" 
            ControlToValidate="TextBox1" Display="Dynamic" 
            MinimumValue="18" MaximumValue="80" Type="Integer"></asp:RangeValidator>
        <asp:Button ID="Button1" runat="server" Text="提交" />
    
    </div>
    </form>
</body>
</html>
