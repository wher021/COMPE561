using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Data;

public partial class ShoppingCart : System.Web.UI.Page
{
    public static NorthWindDataContext database = new NorthWindDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        int orderidd = 0;
        if (!IsPostBack)
        {
            foreach (var v in database.Orders)
            {
                if (v.OrderID > orderidd)
                {
                    orderidd = v.OrderID;
                }
            }
            DateTime now = new DateTime();
            now = DateTime.Now.Date;
            ListDictionary NWorderRow = new ListDictionary();
            NWorderRow.Add("CustomerID", (string)Session["UserID"]);
            NWorderRow.Add("OrderDate", now);
            NWorderRow.Add("OrderID", orderidd + 1);
            LinqDataSource1.Insert(NWorderRow);
            GridView1.DataBind();
            getData(orderidd + 1);
        }
    }
    protected void getData(int oID)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)Session["Table"];
        int rowCount = (int)Session["RowCount"];
        for (int i = 0; i < rowCount + 1; i++)
        {
            ListDictionary ordDet = new ListDictionary();
            ordDet.Add("OrderID", oID);
            foreach (var v in database.Products)
            {
                if (v.ProductName == (string)dt.Rows[i]["Product"])
                {
                    ordDet.Add("ProductID", v.ProductID);
                    break;
                }
            }
            ordDet.Add("UnitPrice", dt.Rows[i]["Price"]);
            ordDet.Add("Quantity", dt.Rows[i]["Quantity"]);
            LinqDataSource2.Insert(ordDet);
            GridView2.DataBind();
        }
    }
}