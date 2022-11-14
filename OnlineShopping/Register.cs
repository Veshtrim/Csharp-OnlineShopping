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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();

           
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            var list = Database.Users();
           
            string username = textBox1.Text;
            string password = textBox2.Text;

            foreach (var u in list)
            {
                if (!u.Username.Contains(username))
                {
                    Database.RegisterUser(username, password);
                    label3.Text = "Ju jeni kyqur me sukses";
                }
                if (u.Username.Contains(username))
                {
                    label3.Text = "Fail";
                }
                
                    
            }

           
        }
    }
}
