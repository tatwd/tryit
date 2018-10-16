<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Ui.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>ID:</h3>
            <p><asp:TextBox ID="StuIdTb" runat="server"></asp:TextBox></p>

            <p>
                <span><asp:Button ID="GetBtn" runat="server" Text="Get Data" OnClick="GetBtn_Click"/></span>
            </p>

            <asp:GridView ID="ViewData" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
