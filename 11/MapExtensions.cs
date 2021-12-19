using System;
using System.Collections.Generic;
using System.Linq;

namespace _11
{
    public static class MapExtensions
    {
        public static int MAX_X(this int[,] map) => map.GetLength(0);
        public static int MAX_Y(this int[,] map) => map.GetLength(1);

        public static int MAX_X<T>(this T[,] map) => map.GetLength(0);
        public static int MAX_Y<T>(this T[,] map) => map.GetLength(1);

        public static void Draw<T>(this T[,] map)
        {
            for (int y = 0; y < map.MAX_Y<T>(); y++)
            {
                for (int x = 0; x < map.MAX_X<T>(); x++)
                {
                    Console.Write($"{map[x, y]}");
                }
                Console.WriteLine();
            }   
        }

        public static T[,] CreateMap<T>(this string[] data, Func<int, int, int, T> process)
        {
            var max_x = data[0].Length;
            var max_y = data.Length;

            // max_x.Show("Max X: ");
            // max_y.Show("Max Y: ");

            T[,] map = new T[max_x, max_y];
            {
                int y = 0;
                foreach (var line in data)
                {
                    int x = 0;
                    foreach (var point in line.ToArray().Select(c => int.Parse(c.ToString())))
                    {
                        map[x, y] = process(point, x, y);
                        x++;
                    }
                    y++;
                }
            }
            return map;
        }

        public static void ForEach<T>(this T[,] map, Action<T> action)
        {
            for (int y = 0; y < map.MAX_Y<T>(); y++)
            {
                for (int x = 0; x < map.MAX_X<T>(); x++)
                {
                    action(map[x,y]);
                }
            }
        }
    }
}