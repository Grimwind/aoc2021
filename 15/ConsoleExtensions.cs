using System;
using System.Collections.Generic;

namespace _15
{
    public static class ConsoleExtensions
    {

        public static void Show(this string data, string header = null)
        {
            if (header is null)
            {
                Console.WriteLine($"{data}");
            }
            else
            {
                Console.WriteLine($"{header}: {data}");
            }
        }

        public static void Show(this int data, string header = null)
        {
            data.ToString().Show(header);
        }
        public static void Show(this long data, string header = null)
        {
            data.ToString().Show(header);
        }

        
    }
}