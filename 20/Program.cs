using System;
using System.IO;
using System.Linq;

namespace _20
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllLines("sample.txt");
            var algo = data[0];

            var max_x = data[2].Length;
            var max_y = data.Length-2;

            var map = data.ToList().GetRange(2, data.Count()-2).ToArray().CreateMap<string>((v, x, y) => v.ToString(), 1);

            map.Draw<string>();
        }
    }
}
