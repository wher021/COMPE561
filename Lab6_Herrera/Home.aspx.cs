using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

public partial class Home : System.Web.UI.Page
{
    public NorthWindDataContext database = new NorthWindDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Add("UserID", "");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        bool flag = false;
        var name = from customer in database.Customers
                   where TextBox1.Text == customer.CustomerID
                   select customer;
        foreach (var c in database.Customers)
        {
            if (c.CustomerID == TextBox1.Text)
            {
                Session["UserID"] = TextBox1.Text;
                TextBox1.Text = "";
                flag = true;
                Response.Redirect("Order.aspx");
            }
        }
        if (!flag)
            TextBox1.Text = "User not found";

    }
}