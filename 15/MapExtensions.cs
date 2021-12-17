using System;
using System.Collections.Generic;

namespace _15
{
    public static class MapExtensions
    {
        public static int[,] EnlargeMap(this int[,] map, int times)
        {

            var result = new int[map.GetLength(0) * times, map.GetLength(1)* times];

            for (int y = 0; y < map.GetLength(1) * times; y++)
            {
                for (int x = 0; x < map.GetLength(0)*times; x++)
                {
                    var increase = x / map.MAX_X() + y / map.MAX_Y();
                    var value = map [x % map.MAX_X(), y % map.MAX_Y()];

                    // It was late, i was tired
                    for (int i = 0; i < increase; i++)
                    {
                        value++;
                        if (value == 10) value = 1;
                    }

                    result[x, y] = value;;
                    
                }
            }

            return result;
        }

        public static (List<Node>, Node[,]) CreateNodes(this int[,] map)
        {
            List<Node> nodes = new List<Node>();
            Node[,] nodeMatrix = new Node[map.MAX_X(), map.MAX_Y()];
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    var node = new Node(x, y);
                    nodeMatrix[x, y] = node;
                    nodes.Add(node);
                }
            }
            return (nodes, nodeMatrix);
        }

        public static int MAX_X(this int[,] map) => map.GetLength(0);
        public static int MAX_Y(this int[,] map) => map.GetLength(1);

        public static void Draw(this int [,] map)
        {
            for (int y = 0; y < map.MAX_Y(); y++)
            {
                for (int x = 0; x < map.MAX_X(); x++)
                {
                    Console.Write($"{map[x, y]}");
                }
                Console.WriteLine();
            }   
        }
    }
}