using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShopping
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();

            dataGridView1.DataSource = Database.Products();

            List<Category> categories = Database.Categories();
            foreach (Category ca in categories)
                comboBox1.Items.Add(ca);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string category = (comboBox1.SelectedItem as Category).CategoryName;
            string description = textBox3.Text;
            decimal price = Convert.ToDecimal(textBox4.Text);

            Database.AddProduct(name,category, description, price);

            dataGridView1.DataSource = Database.Products();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
