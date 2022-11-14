using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShopping
{
    internal class Orders
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string NrPhone { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTimePicker Date { get; set; }
        public decimal Price { get; set; }

       


    }
}
