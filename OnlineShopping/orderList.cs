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
    public partial class orderList : Form
    {
        public orderList()
        {
            InitializeComponent();
            dataGridView1.DataSource = Database.showOrderAll();
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Date"].Visible = false;
        }
    }
}
