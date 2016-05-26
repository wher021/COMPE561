using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopClient
{
    public partial class Form1 : Form
    {
        private ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void GetCategories_Click(object sender, EventArgs e)
        {
            comboBox1.DataSource = client.GetCategories();//get categories
        }

        private void GetProducts_Click(object sender, EventArgs e)
        {
            GenerateGridView();//get products
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            client.AddProduct(textBox1.Text, comboBox1.SelectedItem.ToString(),decimal.Parse(textBox2.Text));
            MessageBox.Show("Product Added Succesfully");
            GenerateGridView();

        }

        private void GenerateGridView()
        {
            try///display the table in gridview
            {
                string[] products = client.GetProducts((string)comboBox1.SelectedItem.ToString());//store all the products in a string array
                var myproducts =
                    from p in products
                    select new { Product = p };
                dataGridView1.DataSource = myproducts.ToList();
                dataGridView1.AutoResizeColumns();
            }
            catch
            {
                MessageBox.Show("Could not display the products of specified category");
            }
        }
    }
}
