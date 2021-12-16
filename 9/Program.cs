﻿using System;
using System.IO;
using System.Linq;

namespace _9
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataLines = File.ReadAllLines("input.txt");
            var max_x = dataLines[0].Length;
            var max_y = dataLines.Count();
            var data = new int[max_x, max_y];
            var low_points = new int[max_x, max_y];
            {
                int y = 0;
                foreach (var dataLine in dataLines)
                {
                    for (int x = 0; x < dataLine.Length; x++)
                    {
                        data[x, y] = int.Parse(dataLine[x].ToString());
                    }
                    y++;
                }
            }

            for (int y = 0; y < data.GetLength(1); y++)
            {
                int previous_x = 9;
                int low_x = -1;

                for (int x = 0; x < data.GetLength(0); x++)
                {
                    

                    if (data[x, y] < previous_x)
                    {    
                        low_x = x;
                    }
                    if (data[x, y] > previous_x)
                    {
                        low_points[low_x, y]=1;
                    }
                    previous_x = data[x, y];
                }
                if (low_x == max_x-1)
                {
                    low_points[low_x, y] = 1;
                }
            }

           // DrawMap(low_points);
            //Console.WriteLine();
            
            for (int x = 0; x < data.GetLength(0); x++)
            {
                int previous_y = 9;
                int low_y = -1;
                for (int y = 0; y < data.GetLength(1); y++)
                {
                    
                    if (data[x, y] < previous_y)
                    {
                        low_y = y;
                    }
                    if (data[x, y] > previous_y)
                    {
                        if (low_points[x, low_y] >= 1) low_points[x, low_y] = 2;
                    }
                    previous_y = data[x, y];
                }
                if (low_y == max_y - 1)
                {
                    if (low_points[x, low_y] >= 1) low_points[x, low_y] = 2;
                }
            }

            int risk_level = 0;
            for (int y = 0; y < data.GetLength(1); y++)
            {
                for (int x = 0; x < data.GetLength(0); x++)
                {
                    if (low_points[x,y] == 2)
                    {
                        risk_level += 1 + data[x, y];
                    }
                }
                
            }

            //DrawMap(data);
            //Console.WriteLine();
            //DrawMap(low_points);

            Console.WriteLine($"Result: {risk_level}");
        }

        public static void DrawMap(int[,] map)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    var disp = map[x, y] == 0 ? "." : map[x, y].ToString();
                    Console.Write($"{map[x, y]}");
                }
                Console.WriteLine();
            }


        }
    }
}
