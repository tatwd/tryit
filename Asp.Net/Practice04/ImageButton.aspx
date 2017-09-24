<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageButton.aspx.cs" Inherits="ImageButton" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" ImageUrl="~/img/test.jpg" />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    
    </div>
    </form>
</body>
</html>
