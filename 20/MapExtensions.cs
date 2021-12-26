using System;
using System.Collections.Generic;
using System.Linq;

namespace _20
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

        public static T[,] CreateMap<T>(this string[] data, Func<char, int, int, T> process, int margin = 0)
        {
            var max_x = data[0].Length;
            var max_y = data.Length;

            // max_x.Show("Max X: ");
            // max_y.Show("Max Y: ");

            T[,] map = new T[max_x+2*margin, max_y+2*margin];
            {
                int y = margin;
                foreach (var line in data)
                {
                    int x = margin;
                    foreach (var character in line.ToArray())
                    {
                        map[x, y] = process(character, x, y);
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