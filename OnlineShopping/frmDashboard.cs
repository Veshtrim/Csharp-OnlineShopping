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
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            RemoveCells();
            Chart();

        }

        private void chart1_Click(object sender, EventArgs e)
        {
            //chart1.DataSource = Database.showOrder();
            //var series = chart1.Series.Add("series1");
            //series.XValueMember = "Category";
            //series.YValueMembers = "Totali";
            //series.Name = "Orders";

            //chart1.DataBind();
            //chart1.Show();



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void Chart()
        {

            chart1.DataSource = Database.showOrder();
            var series = chart1.Series.Add("series1");
            series.XValueMember = "Category";
            series.YValueMembers = "Price";
            series.Name = "Orders";

            chart1.DataBind();
            chart1.Show();

        }
        private void RemoveCells()
        {
            dataGridView1.DataSource = Database.showOrder();
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Name"].Visible = false;
            dataGridView1.Columns["Email"].Visible = false;
            dataGridView1.Columns["Address"].Visible = false;
            dataGridView1.Columns["NrPhone"].Visible = false;
            dataGridView1.Columns["Date"].Visible = false;
            dataGridView1.Columns["Username"].Visible = false;

            


        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            orderList order = new orderList();
            order.ShowDialog();
            
        }
    }
}
