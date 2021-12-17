using System;
using System.IO;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            int depth=0;
            int position=0;
            int aim = 0;

            foreach (var inputLine in input)
            {
                string direction;
                int distance;
                
                (direction, distance) = ParseInput(inputLine);

                switch(direction){
                    case "forward":
                        position += distance;
                        depth += aim * distance;
                        break;
                    case "up":
                        aim -= distance;
                        
                        break;
                    case "down":
                        aim += distance;
                        
                        break;
                }
            }

            Console.WriteLine($"Depth: {depth}; Position: {position}; Result: {depth*position}");
        }

        static void First()
        {
            var input = File.ReadAllLines("input.txt");
            int depth=0;
            int position=0;

            foreach (var inputLine in input)
            {
                string direction;
                int distance;
                
                (direction, distance) = ParseInput(inputLine);

                switch(direction){
                    case "forward":
                        position += distance;
                        break;
                    case "up":
                        depth -= distance;
                        break;
                    case "down":
                        depth += distance;
                        break;
                }
            }

            Console.WriteLine($"Depth: {depth}; Position: {position}; Result: {depth*position}");
        }

        static (string, int) ParseInput(string inputLine)
        {
            var result = inputLine.Split(' ');
            var direction = result[0];
            var number = int.Parse(result[1]);

            return (direction, number);
        }
    }
}
