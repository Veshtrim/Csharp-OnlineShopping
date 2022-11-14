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
    public partial class frmLogin : Form
    {
        public static string user{ get; set; }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            IsAdminOrUser.Username = textBox1.Text;
            string mesazh = Database.LoginUser(username, password);
            if (mesazh == "OK")
            {
                this.DialogResult = DialogResult.OK;
                this.Hide();
                MainForm main = new MainForm();
                main.ShowDialog();
                


            }
            else
                label3.Text = "Ju lutem shikoni nese i keni vendosur mire Username dhe Password";
             

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.ShowDialog();
        }
    }
}
