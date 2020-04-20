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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            JsonStreamer.Read();
            Output();
        }

        private void add_Click(object sender, EventArgs e)
        {
            Form2 window = new Form2();
            window.ShowDialog();

            Product stuff = new Product();

            stuff.Name = window.name;
            stuff.Cost = window.cost;
            stuff.Description = window.description;
            stuff.Availability = window.availability;

            Product.products.Add(stuff);
            JsonStreamer.Write(Product.products);

            Output();
        }

        private void Output()
        {
            outputList.Items.Clear();

            for(var i = 0; i < Product.products.Count; i++)
            {
                outputList.Items.Add($"Name: {Product.products[i].Name} Cost: {Product.products[i].Cost} " +
                    $"Description: {Product.products[i].Description} Availability: {Product.products[i].Availability}");
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            string selected = outputList.SelectedItem.ToString();

            foreach (var i in Product.products)
            {
                if ($"Name: {i.Name} Cost: {i.Cost} Description: {i.Description} Availability: {i.Availability}" == selected)
                {
                    Product.products.Remove(i);
                    JsonStreamer.Write(Product.products);

                    break;
                }
            }

            Output();
        }

        private void change_Click(object sender, EventArgs e)
        { 
            Form2 change = new Form2();
            change.ShowDialog();

            string selected = outputList.SelectedItem.ToString();

            for(var i = 0; i < Product.products.Count; i++)
            {
                if ($"Name: {Product.products[i].Name} " +
                    $"Cost: {Product.products[i].Cost} " +
                    $"Description: {Product.products[i].Description} " +
                    $"Availability: {Product.products[i].Availability}"
                    == selected)
                {
                    Product.products[i].Name = change.name;
                    Product.products[i].Cost = change.cost;
                    Product.products[i].Description = change.description;
                    Product.products[i].Availability = change.availability;
                }
            }

            JsonStreamer.Write(Product.products);
            Output();
        }
    }
}
