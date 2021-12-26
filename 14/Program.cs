using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _14
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllLines("input.txt");

            var polymer = new Polymer(data[0]);

            var transitions = new List<Transition>();
            for (int i = 2; i < data.Length; i++)
            {
                transitions.Add(new Transition(data[i]));
            }

            for (int i = 1; i <= 40; i++)
            {
                polymer = polymer.Grow(transitions);
            }

            Console.WriteLine($"Result: {polymer.Analyze()}");
        }

        public static string Grow(string polymer, Dictionary<string, string> transitions)
        {
            var newPolymer = new StringBuilder();
            for (int i = 0; i < polymer.Length-1; i++)
            {
                newPolymer.Append(polymer[i]);
                var key = polymer.Substring(i, 2);
                if (transitions.ContainsKey(key))
                {
                    newPolymer.Append(transitions[key]);
                }
            }
            newPolymer.Append(polymer[polymer.Length-1]);
            return newPolymer.ToString();
        }

        public static (long, long) Analyze(string polymer)
        {
            var counts = new Dictionary<char,long>();
            for (int i = 0; i < polymer.Length ; i++)
            {
                var element = polymer[i];
                if (!counts.ContainsKey(element))
                {
                    counts.Add(element, 0);
                }

                counts[element] += 1;
            }
            var lastElement = counts.OrderBy(x => x.Value).Last();
            var firstElement = counts.OrderBy(x => x.Value).First();

            Console.WriteLine($"Last: {lastElement.Key} -> {lastElement.Value}");
            Console.WriteLine($"First: {firstElement.Key} -> {firstElement.Value}");

            var resultList = counts.Select(x => x.Value).OrderBy(v => v).ToList();
            return (resultList.Last(), resultList.First());
        }
    }
}
