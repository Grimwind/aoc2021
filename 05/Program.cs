using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _5
{
    class Program
    {
        public static int MAX_X = 1000;
        public static int MAX_Y = 1000;

        static void Main(string[] args)
        {
            var data = File.ReadAllLines("input.txt");

            var ridges = new List<Ridge>();
            foreach (var dataLine in data)
            {
                ridges.Add(new Ridge(dataLine));
            }
            

            int [,] map = new int[MAX_X,MAX_Y];

            var horizontal = ridges.Where(r => r.IsHorizontal);
            var vertical = ridges.Where(r=> r.IsVertical);

            var diagonal = ridges.Where(r => r.IsHorizontal == false && r.IsVertical == false);

            Console.WriteLine($"Horizontal: {horizontal.Count()}; Vertical: {vertical.Count()}; Diagonal: {diagonal.Count()}");

            

            foreach (var ridge in ridges)
            {
                foreach(Point ridgePoint in ridge)
                {
                    map[ridgePoint.X, ridgePoint.Y]++;
                }
            }

            //foreach (var ridge in vertical)
            //{
            //    foreach (Point ridgePoint in ridge)
            //    {
            //        map[ridgePoint.X, ridgePoint.Y]++;
            //    }
            //}

            int count = 0;
            for(int x = 0; x < MAX_X; x++)
            { 
               for(int y=0; y <MAX_Y; y++)
                {
                    if (map[x, y] > 1) count++;
                }
            }

            //DrawMap(map);

            Console.WriteLine($"Result {count}");
        }


        public static void DrawMap(int [,] map)
        {
            for (int y = 0; y < MAX_Y; y++)
            {
                for (int x = 0; x < MAX_X; x++)
                {
                    var disp = map[x, y] == 0 ? "." : map[x, y].ToString();
                    Console.Write($"{disp}");
                }
                Console.WriteLine();
            }
                
            
        }
    }
}
