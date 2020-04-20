using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;

namespace ShopForms
{
    class JsonStreamer
    {
        public static void Write(List<Product> products)
        {
            using (FileStream fstream = new FileStream("products.json", FileMode.Create))
            {
                JsonSerializer.SerializeAsync(fstream, products);
            }
        }

        public static void Read()
        {
            using (FileStream fstream = new FileStream("products.json", FileMode.OpenOrCreate))
            {
                try
                {
                    Product.products = JsonSerializer.DeserializeAsync<List<Product>>(fstream).Result;
                }
                catch (Exception ex)
                {
                    Console.Write("\a");
                }
            }
        }
    }
}

