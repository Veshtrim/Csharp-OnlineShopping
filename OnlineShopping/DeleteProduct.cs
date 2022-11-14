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
    public partial class DeleteProduct : Form
    {
        public DeleteProduct()
        {
            InitializeComponent();
            dataGridView1.DataSource = Database.Products();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
               



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox5.Text);
            Database.DeleteProduct(id);
            dataGridView1.DataSource = Database.Products();
        }

        private void dataGridView1_Move(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Database.Products();
            dataGridView1.Refresh();
            dataGridView1.Update();
        }
    }
}
