using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Data;

public partial class Order : System.Web.UI.Page
{
    public static NorthWindDataContext database = new NorthWindDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var value = from product in database.Products
                    where ListBox1.SelectedItem.Value == product.ProductName
                    select new { found = product.UnitPrice };
        decimal sum;
        foreach (var v in value)
        {
            sum = (v.found.Value) * decimal.Parse(DropDownList1.SelectedItem.Value);
            TextBox1.Text = sum.ToString();
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListBox1_SelectedIndexChanged(sender,e);
    }

    private bool _disableAutoPostBack = false;

    protected void RLCompareParameter_SelectedIndexChanged(object sender, EventArgs e)
    {
        _disableAutoPostBack = true;
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ListBox1.AutoPostBack = !_disableAutoPostBack;
        DropDownList1.AutoPostBack = !_disableAutoPostBack;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "Total: $" + TextBox1.Text;
        Label1.Visible = true;
        Button2.Visible = true;
        if (ViewState["CurrentTable"] == null)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Product", typeof(string)));
            dt.Columns.Add(new DataColumn("Quantity", typeof(Int16)));
            dt.Columns.Add(new DataColumn("Price", typeof(decimal)));
            for (int i = 0; i < 20; i++)
                dt.Rows.Add();
            dt.Rows[0]["Product"] = ListBox1.SelectedItem.Value;
            dt.Rows[0]["Quantity"] = DropDownList1.SelectedItem.Value;
            dt.Rows[0]["Price"] = TextBox1.Text;
            ViewState["CurrentTable"] = dt;
            ViewState["RowNum"] = 1;
            GridView1.DataSource = ViewState["CurrentTable"];
            GridView1.DataBind();
        }
        else
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            int i = (int)ViewState["RowNum"];
            dtCurrentTable.Rows[i]["Product"] = ListBox1.SelectedItem.Value;
            dtCurrentTable.Rows[i]["Quantity"] = DropDownList1.SelectedItem.Value;
            dtCurrentTable.Rows[i]["Price"] = TextBox1.Text;
            decimal sum = 0;
            i++;
            for (int j = 0; j < i; j++)
                sum += (decimal)dtCurrentTable.Rows[j]["Price"];
            Label1.Text = "Total: $" + sum;
            ViewState["RowNum"] = i;
            ViewState["CurrentTable"] = dtCurrentTable;
            GridView1.DataSource = ViewState["CurrentTable"];
            GridView1.DataBind();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)ViewState["CurrentTable"];
        int rowCount = (int)ViewState["RowNum"] - 1;
        Session.Add("Table", dt);
        Session.Add("RowCount", rowCount);
        Response.Redirect("Checkout.aspx");
    }
}