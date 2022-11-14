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
    public partial class frmComputers : Form
    {
        public frmComputers()
        {
            InitializeComponent();
            dataGridView1.DataSource = Database.ProductsComputer();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.DataSource = Database.ProductsComputer();
        }
    }
}
