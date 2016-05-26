using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

public partial class registration : System.Web.UI.Page
{
    NorthWindDataContext database = new NorthWindDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        ListDictionary customerRow = new ListDictionary();
        customerRow.Add("ContactName", firstname.Text + " " + lastname.Text);
        customerRow.Add("CustomerID",(firstname.Text.Substring(0,3) + lastname.Text.Substring(0,2)));
        customerRow.Add("CompanyName", company_name.Text);
        customerRow.Add("Phone", phone.Text);
        LinqDataSource1.Insert(customerRow);
        GridView1.DataBind();
        form1.Visible = false;
        form2.Visible = true;
        Label1.Text = firstname.Text.Substring(0, 3) + lastname.Text.Substring(0, 2);
    }
}