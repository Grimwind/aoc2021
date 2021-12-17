using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _15
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllLines("input.txt");

            var max_x = data[0].Length;
            var max_y = data.Length;

            // max_x.Show("Max X: ");
            // max_y.Show("Max Y: ");


            int[,] map = new int[max_x, max_y];
            {
                int y = 0;
                foreach (var line in data)
                {
                    int x = 0;
                    foreach (var point in line.ToArray().Select(c => int.Parse(c.ToString())))
                    {
                        map[x, y] = point;
                        x++;
                    }
                    y++;
                }
            }


            map = map.EnlargeMap(5);

            (var nodes, var nodeMatrix) = map.CreateNodes();

            // Mark final node
            var finalNode = nodeMatrix[map.MAX_X() - 1, map.MAX_Y() - 1];
            finalNode.Final = true;

            // Mark start node
            var startNode = nodeMatrix[0, 0];
            startNode.Distance = 0;

            List<Node> process = new List<Node>();
            process.Add(startNode);

            var stop = false;
            long count = 0;
            do
            {
                var current = process
                    .OrderBy(n => n.Distance)
                    .First();

                stop = ProcessNode(current, nodeMatrix, map, ref process);
                process.Remove(current);

                count++;
                Console.WriteLine($"Node {count}/{nodes.Count()} P: {process.Count()}");
                

            } while (!stop);

            finalNode.Distance.Value.Show("Result: ");
        }

        public static bool ProcessNode(Node current, Node[,] nodeMatrix, int[,] map, ref List<Node> process)
        {
            if (current.Final) return true;
            var x = current.X;
            var y = current.Y;

            var max_x = map.GetLength(0);
            var max_y = map.GetLength(1);
            // For all connected nodes
            if (current.X > 0)
            {
                // There is a node to the left
                var node = nodeMatrix[x - 1, y];
                if (!node.Visited)
                {
                    node.TrySetDistance(current.Distance.Value + map[x - 1, y], out var first);
                    if (first) process.Add(node);
                }
            }

            if (current.X < max_x - 1)
            {
                // There is a node to the right
                var node = nodeMatrix[x + 1, y];
                if (!node.Visited)
                {
                    node.TrySetDistance(current.Distance.Value + map[x + 1, y], out var first);
                    if (first) process.Add(node);
                }
            }

            if (current.Y > 0)
            {
                // There is a node to the right
                var node = nodeMatrix[x, y - 1];
                if (!node.Visited)
                {
                    node.TrySetDistance(current.Distance.Value + map[x, y - 1], out var first);
                    if (first) process.Add(node);
                }
            }

            if (current.Y < max_y - 1)
            {
                // There is a node to the right
                var node = nodeMatrix[x, y + 1];
                if (!node.Visited)
                {
                    node.TrySetDistance(current.Distance.Value + map[x, y + 1], out var first);
                    if (first) process.Add(node);
                }
            }

            current.Visited = true;
            return false;
        }
    }
}
