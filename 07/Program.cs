using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            var crabs = File.ReadAllText("input.txt").Split(',').Select(x => int.Parse(x)).ToList();

            var minFuel = int.MaxValue;
            for (int i = crabs.Min(); i <= crabs.Max(); i++)
            {
                var value = crabs.Sum(c => CalculateFuelCrab(i, c));
                Console.WriteLine($"Column: {i}, Fuel: {value}, MinFuel: {minFuel}");
                if (value < minFuel) minFuel = value;
            }

            Console.WriteLine($"Result: {minFuel}");
        }

        public static int CalculateFuelFlat(int x1, int x2) => Math.Abs(x1 - x2);

        public static int CalculateFuelCrab(int x1, int x2)
        {
            var distance = Math.Abs(x1 - x2);
            return Enumerable.Range(1, distance).Sum();
        }
    }
}
