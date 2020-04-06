using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shop
{
    class JsonStreamer
    {
        public static void Write(List<Product> products)
        {
            using (FileStream fstream = new FileStream("products.json", FileMode.Truncate))
            {
                JsonSerializer.SerializeAsync(fstream, products);
            }
        }

        public static void Read()
        {
            using (FileStream fstream = new FileStream("products.json", FileMode.Open))
            {
                try
                {
                    RequestHandler.products = JsonSerializer.DeserializeAsync<List<Product>>(fstream).Result;
                }
                catch
                {
                    Console.Write("\a");
                }
            }
        }
    }
}
