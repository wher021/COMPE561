<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
</head>
<body style="background-color:lightblue;">
    <form id="form1" runat="server">
    <div>
        <h1>Registration</h1>
        <a href="Home.aspx">Home</a>
        <h4>Complete the following fields, then click the register button:</h4>
        <ul style="list-style-type: none">        
            <li><asp:TextBox ID="firstname" runat="server"></asp:TextBox> First Name</li>
            <li><br /></li>
            <li><asp:TextBox ID="lastname" runat="server"></asp:TextBox> Last Name</li>
            <li><br /></li>
            <li><asp:TextBox ID="phone" runat="server"></asp:TextBox> Phone Number</li>
            <li><br /></li>
            <li><asp:TextBox ID="company_name" runat="server"></asp:TextBox> Company</li>
            <li><br /></li>
            <li><asp:Button ID="submit" runat="server" Text="Register!" OnClick="submit_Click" /></li>
        </ul>
    </div>
    </form>
    <form id="form2" runat="server" visible="false">
        <div style="background-color: azure">
            <h3>Congratulations! Here is your UserID.</h3>
            <p>Your login is: <asp:Label ID="Label1" runat="server" Font-Size="22pt"></asp:Label></p>
            <p>Click <a href="Home.aspx">here</a> to return home.</p>
        </div>
        <div><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomerID" DataSourceID="LinqDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" ReadOnly="True" SortExpression="CustomerID" />
                <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
                <asp:BoundField DataField="ContactName" HeaderText="ContactName" SortExpression="ContactName" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="NorthwindDataContext" EntityTypeName="" TableName="Customers" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
            </asp:LinqDataSource>
        </div>
    </form>
</body>
</html>
