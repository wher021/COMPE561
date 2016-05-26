using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebsiteClient : System.Web.UI.Page
{
    private ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient();

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void GetCategories_btn_Click(object sender, EventArgs e)
    {
        DropDownList1.DataSource = client.GetCategories();
        DropDownList1.DataBind();
    }
    protected void GetProducts_btn_Click(object sender, EventArgs e)
    {
        GenerateGridView();
        
    }

    protected void AddProduct_Click(object sender, EventArgs e)
    {
        client.AddProduct(TextBox1.Text, DropDownList1.SelectedItem.ToString(), decimal.Parse(TextBox2.Text));
        Response.Write("Product Added Succesfully");
        GenerateGridView();
    }

    private void GenerateGridView()
    {
        try///display the table in gridview
        {
            string[] products = client.GetProducts((string)DropDownList1.SelectedItem.ToString());//store all the products in a string array
            var myproducts =
                from p in products
                select new { Product = p };
            GridView1.DataSource = myproducts.ToList();
            GridView1.DataBind();
        }
        catch
        {
            Response.Write("Could not display the products of specified category");
        }
    }
}