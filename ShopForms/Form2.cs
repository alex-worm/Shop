using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopForms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string name;
        public int cost;
        public string description;
        public bool availability;

        private void accept_Click(object sender, EventArgs e)
        {
            name = nameBox.Text;
            cost = int.Parse(costBox.Text);
            description = descriptionBox.Text;
            availability = bool.Parse(availabilityBox.Text);

            Close();
        }
    }
}
