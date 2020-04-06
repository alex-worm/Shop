using System;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonStreamer.Read();

            while(true)
            {
                RequestHandler.RequestInput();
            }
        }
    }
}
