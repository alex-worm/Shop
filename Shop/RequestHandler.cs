using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    class RequestHandler
    {
        public static List<Product> products = new List<Product>();

        public static void RequestInput()
        {
            string request = InputAndOutput.DataEntry("Enter a request: ");

            if (request == "close")
            {
                Environment.Exit(0);
            }
            else if (request == "add")
            {
                AddProduct();
            }
            else if (request == "output")
            {
                Output();
            }
            else if (request == "remove") 
            {
                Remove();
            }
            else if(request=="change")
            {
                Change();
            }
            else if (request == "write")
            {
                Write();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\aIncorrect request");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        private static void AddProduct()
        {
            Product stuff = new Product();
            
            stuff.Name = InputAndOutput.DataEntry("Enter product's name: ");

            while (true)
            {
                if (int.TryParse(InputAndOutput.DataEntry("Enter product's cost: "), out int cost))
                {
                    stuff.Cost = cost;

                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\aIncorrect format");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

            stuff.Description = InputAndOutput.DataEntry("Enter product's description: ");

            while (true)
            {
                if (bool.TryParse(InputAndOutput.DataEntry("Enter product's availability: "), out bool availability))
                {
                    stuff.Availability = availability;

                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\aIncorrect format");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            
            products.Add(stuff);
            JsonStreamer.Write(products);
        }

        private static void Output()
        {
            foreach (var i in products)
            {
                Console.WriteLine($"\nName: {i.Name}\nCost: {i.Cost}\nDescription: {i.Description}\nAvailability: {i.Availability}\nID: {i.Id}\n");
            }
        }

        private static void Remove()
        {
            int id = int.Parse(InputAndOutput.DataEntry("Enter product's ID to remove: "));

            foreach(var i in products)
            {
                if(i.Id==id)
                {
                    products.Remove(i);
                    JsonStreamer.Write(products);

                    break;
                }
            }
        }

        private static void Change()
        {
            int id = int.Parse(InputAndOutput.DataEntry("Enter product's ID to change: "));

            for (var i = 0; i < products.Count; i++)
            {
                if (products[i].Id == id)
                {
                    products[i].Name = InputAndOutput.DataEntry("Enter product's name: ");

                    while (true)
                    {
                        if (int.TryParse(InputAndOutput.DataEntry("Enter product's cost: "), out int cost))
                        {
                            products[i].Cost = cost;

                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\aIncorrect format");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }

                    products[i].Description = InputAndOutput.DataEntry("Enter product's description: ");

                    while (true)
                    {
                        if (bool.TryParse(InputAndOutput.DataEntry("Enter product's availability: "), out bool availability))
                        {
                            products[i].Availability = availability;

                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\aIncorrect format");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }

                    JsonStreamer.Write(products);
                }
            }
        }

        private static void Write()
        {
            JsonStreamer.Write(products);
        }
    }
}
