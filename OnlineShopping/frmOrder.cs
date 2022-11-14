using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OnlineShopping
{
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();
            dataGridView1.DataSource = Database.Products();
            List<Category> categories = Database.Categories();
            foreach (Category ca in categories)
                comboBox1.Items.Add(ca);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("A jeni i sigurt qe deshironi ta bleni", "OrderBox", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) { 
            string username = txt1.Text;
                string email = txt2.Text;
                string nrphone = txt3.Text;
                string address = txt4.Text;
                string name = txt5.Text;
                string category = txt6.Text;
                DateTimePicker date = txt7;
                decimal price = decimal.Parse(txt8.Text);
                Database.Order(username, email, nrphone, address, name, category, date, price);
                MessageBox.Show("Porosia eshte bere me sukses");
            }
            else {
                MessageBox.Show("Porosia ka deshtuar");
            }

            


            dataGridView1.DataSource = Database.Products();
            
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
               
                txt5.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt6.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt8.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();




            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            string category = (comboBox1.SelectedItem as Category).CategoryName; ;

            dataGridView1.DataSource = Database.Products(name, category);

           
        }
    }
}
