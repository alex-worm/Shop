using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopForms
{
    class Product
    {        
        public Product()
        {
            Id = new Random().Next(int.MinValue, int.MaxValue);
        }

        public static List<Product> products = new List<Product>();

        public int Id { get; set; }

        public string Name { get; set; }

        public int Cost { get; set; }

        public string Description { get; set; }

        public bool Availability { get; set; }
    }
}
