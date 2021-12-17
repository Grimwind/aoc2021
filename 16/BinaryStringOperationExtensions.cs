using System;

namespace _16
{
    public static class BinaryStringOperationExtensions
    {
        public static int ReadBinaryNumber(this string data, int startIdx, int length)
        {
            var str = data.Substring(startIdx, length);
            return Convert.ToInt16(str, 2);
        }

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

        public static void Show (this int data, string header = null)
        {
            data.ToString().Show(header);
        }
        public static void Show (this long data, string header = null)
        {
            data.ToString().Show(header);
        }
    }
}