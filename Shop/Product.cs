using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    class Product
    {
        public Product()
        {
            Id = new Random().Next(int.MinValue, int.MaxValue);
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Cost { get; set; }

        public string Description { get; set; }

        public bool Availability { get; set; }
    }
}
