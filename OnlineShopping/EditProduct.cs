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
    public partial class EditProduct : Form
    {
        public EditProduct()
        {
            InitializeComponent();
            dataGridView1.DataSource = Database.Products();
            List<Category> categories = Database.Categories();
            foreach (Category ca in categories)
                comboBox1.Items.Add(ca);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox5.Text);
            string name = textBox1.Text;
            string category = (comboBox1.SelectedItem as Category).CategoryName;
            string description = textBox3.Text;
            decimal price = Convert.ToDecimal(textBox4.Text);

            Database.EditProduct(id,name, category, description, price);

            dataGridView1.DataSource = Database.Products();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
