<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body style="background-color:lightblue;">
    
    <form id="form1" runat="server">
    <h2>Welcome. Please browse our products.</h2>
    <div>
        <asp:ListBox ID="ListBox1" AutoPostBack="False" EnableViewState="False" runat="server" DataSourceID="ItemDataSource" DataTextField="ProductName" DataValueField="ProductName" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Height="150px" Width="300px"></asp:ListBox>
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <p style="margin-left: 10px; display: inline">Price</p>
        <br />
        <br />
        <asp:DropDownList ID="DropDownList1" AutoPostBack="False" EnableViewState="False" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
             <asp:ListItem Value="1"></asp:ListItem>
             <asp:ListItem Value="2"></asp:ListItem>
             <asp:ListItem Value="3"></asp:ListItem>
             <asp:ListItem Value="4"></asp:ListItem>
             <asp:ListItem Value="5"></asp:ListItem>
             <asp:ListItem Value="6"></asp:ListItem>
             <asp:ListItem Value="7"></asp:ListItem>
             <asp:ListItem Value="8"></asp:ListItem>
             <asp:ListItem Value="9"></asp:ListItem>
        </asp:DropDownList>
        <p style="margin-left: 10px; display: inline">Quantity</p>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Add to Shopping Cart" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False" BackColor="LightBlue" Font-Bold="True" Font-Size="20pt"></asp:Label>
        <asp:Button ID="Button2" runat="server" Text="CheckOut" Visible="False" OnClick="Button2_Click" />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" GridLines="None" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:LinqDataSource ID="ItemDataSource" runat="server" ContextTypeName="NorthwindDataContext" EntityTypeName="" TableName="Products">
        </asp:LinqDataSource>     
    </div>    
    </form>
</body>
</html>
