<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:lightblue;" >
    <form id="form1" runat="server">
        <h1 align="center">Welcome</h1>
        <div align="center">
            <h3>Please Log In: </h3>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
        </div>
        <p align="center">Create an account <a href="registration.aspx">Register Here</a></p>
    </form>
</body>
</html>
