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
    public partial class frmAccessories : Form
    {
        public frmAccessories()
        {
            InitializeComponent();
            dataGridView1.DataSource = Database.ProductsAccessories();
        }
    }
}
