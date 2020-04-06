using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    class InputAndOutput
    {
        public static string DataEntry(string message)
        {
            Console.Write(message);

            return Console.ReadLine();
        }
    }
}
