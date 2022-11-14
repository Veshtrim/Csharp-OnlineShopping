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
    public partial class shtoCategory : Form
    {
        public shtoCategory()
        {
            InitializeComponent();
            dataGridView1.DataSource = Database.Categories();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            Database.ShtoCategory(name);


            dataGridView1.DataSource = Database.Categories();
        }
    }
}
