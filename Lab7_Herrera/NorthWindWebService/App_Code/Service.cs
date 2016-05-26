using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    NorthWindDataContext database = new NorthWindDataContext();

	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

    public string[] GetCategories()
    {
        var categories = from c in database.Categories
                         select c.CategoryName;

        return categories.ToArray();
    }

    public string[] GetProducts(string category)
    {
        var product = from p in database.Products
                      where p.Category.CategoryName == category
                      select new { productn = p.ProductName, price = p.UnitPrice };

        List<string> returnList = new List<string>();
        string[] returnString;

        foreach (var i in product)
        {
            returnList.Add(i.productn + " " + "$" + i.price);
        }

        return returnString = returnList.ToArray();
    }

    public void AddProduct(string name, string category, decimal price)//add product to specific category
    {
        var categories = from c in database.Categories//Get category
                         where c.CategoryName == category
                         select new { GetCat = c.CategoryID };
        int myCategory = 0;
       // SomeClass a = new SomeClass();
        //myCategory = a.GetCat;
        foreach (var i in categories)
        {
            myCategory = i.GetCat;
        }

        var productIDs = from p in database.Products//selects all Products ID's
                         select p.ProductID;

        int count = 0;
        foreach (var i in productIDs)
        {
            count++;
        }

        int newid = count + 1;

        Product newproduct = new Product();
        newproduct.ProductID = newid;
        newproduct.ProductName = name;
        newproduct.UnitPrice = price;
        newproduct.CategoryID = myCategory;//assign category to new product

        database.Products.InsertOnSubmit(newproduct);
        database.SubmitChanges();


    }

    public class SomeClass
    {
        public int GetCat { get; set; }
    }

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}
}
