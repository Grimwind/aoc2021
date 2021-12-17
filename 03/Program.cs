using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = GetData("input.txt");
            var max_x = data[0].Length;
            var max_y = data.Count;
            //DisplayData(data);

            int[] gammaRateBinary =  new int[max_x];
            int[] epsilonRateBinary = new int[max_x];
            var o2Filtered = data.ToList();
            var co2Filtered = data.ToList();

            for(int x=0;x<max_x;x++)    
            {
                Console.WriteLine($"Iteration {x}");
                var bit = GetMostCommonBit(data, x);

                gammaRateBinary[x] = bit;

                if (o2Filtered.Count > 1)
                {
                    var cBit = GetMostCommonBit(o2Filtered, x);
                    o2Filtered = o2Filtered.FilterOnColumn(x, cBit);
                    // Console.WriteLine($"Most Common Bit: {cBit}; Filtered list count: {o2Filtered.Count}");
                    // DisplayData(o2Filtered);
                }

                if (co2Filtered.Count > 1)
                {
                    co2Filtered = co2Filtered.FilterOnColumn(x, GetMostCommonBit(co2Filtered, x) ^ 1);
                }
            }

            var gammaRating = gammaRateBinary.ToInteger();
            var epsilonRating = gammaRating ^ GetFlipper(max_x);

            Console.WriteLine($"Gamma Rate Binary: {gammaRateBinary.ToDisplayString()}, Gamma Rate: {gammaRateBinary.ToInteger()}");
            Console.WriteLine($"Epsilon Rate: {epsilonRating}");

            var result = gammaRating * epsilonRating;
            Console.WriteLine($"Result: {result}");

            Console.WriteLine("-----------------");

            int [] o2ratingBinary = o2Filtered.Single();
            Console.WriteLine($"O2 Rating Binary: {o2ratingBinary.ToDisplayString()}, O2 Rating: {o2ratingBinary.ToInteger()}");

            int [] co2ratingBinary = co2Filtered.Single();
            Console.WriteLine($"CO2 Rating Binary: {co2ratingBinary.ToDisplayString()}, CO2 Rating: {co2ratingBinary.ToInteger()}");
             
            var result2 = o2ratingBinary.ToInteger() * co2ratingBinary.ToInteger();
            Console.WriteLine($"Result: {result2}");
        }

        static int GetMostCommonBit(List<int[]> data, int column)
        {
            var number_of_ones = 0;
            foreach (var entry in data)
            {
                if (entry[column] == 1) number_of_ones++;
            }
            
            var result = number_of_ones >=  ((float) data.Count/2) ? 1 : 0;

            // Console.WriteLine($"Column {column}; 1: {number_of_ones}; Count: {data.Count}; Result: {result}");
            return result;
        }

        static int GetFlipper(int length){
            string value = string.Empty;
            for (int i = 0; i < length; i++)
            {
                value+="1";
            }
            return Convert.ToInt32(value, 2);
        }

        static void DisplayData(List<int[]> data)
        {

            var max_x = data[0].Length;
            var max_y = data.Count;

            for(int y=0;y<max_y;y++)
            {
                for(int x=0;x<max_x;x++)    
                {
                    Console.Write(data[y][x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"max_x: {max_x}, max_y: {max_y}");
        }

        static List<int[]> GetData(string filename)
        {
            var input = File.ReadAllLines(filename);

            var max_x = input[0].Length;
            var max_y = input.Length;
            
            var resultList = new List<int[]>();

            foreach (var inputLine in input)
            {
                var result = new int[max_x];
                for(int x=0 ; x<max_x ; x++)
                {
                    result[x] = inputLine[x] == '1' ? 1 : 0;   
                }
                resultList.Add(result);
            }
            return resultList;
        }
    }
}
