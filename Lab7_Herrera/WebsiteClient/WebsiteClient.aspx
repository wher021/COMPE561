<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebsiteClient.aspx.cs" Inherits="WebsiteClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Welcome to Willy's Web Client</h1>
    <div>
        <asp:Button ID="GetCategories_btn" runat="server" Text="GetCategories" OnClick="GetCategories_btn_Click" />
        <asp:Button ID="GetProducts_btn" runat="server" Text="GetProducts" OnClick="GetProducts_btn_Click" />
        <asp:Button ID="AddProduct" runat="server" Text="AddProduct" OnClick="AddProduct_Click" />
        <br />
        <br />
        <div>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="50px" Width="165px" AutoPostBack="True"></asp:DropDownList> 
        
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label" style="padding-left: 170px" >ProductName</asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Label" style="padding-left: 70px" >Cost</asp:Label>
        </div>
        
    </div>
        <div id="content">
            <div id="left">
            <asp:GridView ID="GridView1" runat="server"></asp:GridView></div>
            <div id="right"><p>1. Click GetCategories to populate dropdownlist<br />
                               2.Select Category from dropdownlist and click GetProducts<br />
                               3.Enter product name and cost and click AddProduct</p></div>
        </div>

    </form>
</body>
</html>
