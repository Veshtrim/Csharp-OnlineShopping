using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OnlineShopping
{
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
            dataGridView1.DataSource = Database.Products();
            isAdmin();
            List<Category> categories = Database.Categories();
            foreach (Category ca in categories)
                comboBox1.Items.Add(ca);
            dataGridView1_Click(null, null);
        }
        public void isAdmin()
        {


            string userrole = IsAdminOrUser.Username;
            if (userrole == "admin" || userrole == "Admin")
            {

                button1.Show();
                button2.Show();
                button3.Show();
                //button4.Show();
                button5.Show();
                button6.Show();
                button7.Show();

            }
            else
            {

                button1.Hide();
                button2.Hide();
                button3.Hide();
                //button4.Hide();
                button5.Hide();
                button6.Hide();
                button7.Hide();
            }



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

           dataGridView1.DataSource = Database.Products();
            dataGridView1.Refresh();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            AddProduct addProduct = new AddProduct();
            addProduct.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditProduct editProduct = new EditProduct();
            editProduct.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmOrder order = new frmOrder();
            order.Show();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            string category = (comboBox1.SelectedItem as Category).CategoryName; ;

            dataGridView1.DataSource = Database.Products(name, category);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteProduct deleteProduct = new DeleteProduct();
            deleteProduct.ShowDialog();
        }

        private void frmProducts_Move(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Database.Products();
            dataGridView1.Refresh();
            dataGridView1.Update();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            shtoCategory shto = new shtoCategory();
            shto.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EditCategory editCategory = new EditCategory();
            editCategory.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            deleteCategory deleteCategory = new deleteCategory();
            deleteCategory.ShowDialog();
        }
    }
}
