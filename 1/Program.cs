using System;
using System.Collections.Generic;
using System.IO;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            var normalized = GetNormalizedInput();
            var result1 = Foo1(normalized);

            var result2 = Foo1b(normalized);
            
            Console.WriteLine($"The number of increases is {result1}");
            Console.WriteLine($"The number of clustered increases is {result2}");
        }

        static List<int> GetNormalizedInput()
        {
            var input = File.ReadAllLines("input.txt");
            var normalized = new List<int>();
            int parseResult;
            int line = 0;
            foreach(var value in input)
            {
                line++;
                var success = int.TryParse(value, out parseResult);
                if (success != true)
                {
                    Console.WriteLine($"This is wrong in line {line}: {value}");
                    return null;
                }
                normalized.Add(parseResult);
            }
            return normalized;
        }

        static int Foo1b(List<int> input)
        {
            int result = 0;
            for(int ii=3;ii < input.Count; ii++)
            {
                if (input[ii-3]< input[ii])
                {
                    result++;
                }
            }

            return result;
        }

        static int Foo1(List<int> input)
        {
            int result = 0;
            for(int ii=1;ii < input.Count; ii++)
            {
                if (input[ii-1]< input[ii])
                {
                    result++;
                }
            }

            return result;
        }
    }
}
