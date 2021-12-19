using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _12
{
    class Program
    {
        static void Main(string[] args)
        {
            var connections = File.ReadAllLines("input.txt");

            var caveList = new List<Cave>();

            foreach (var connection in connections)
            {
                var caves = connection.Split('-');
                var firstCave = caveList.SingleOrDefault(c => c.Name == caves[0]);
                if (firstCave == null)
                {
                    firstCave = new Cave(caves[0]);
                    caveList.Add(firstCave);
                }

                var secondCave = caveList.SingleOrDefault(c => c.Name == caves[1]);
                if (secondCave == null)
                {
                    secondCave = new Cave(caves[1]);
                    caveList.Add(secondCave);
                }

                firstCave.Connect(secondCave);
                secondCave.Connect(firstCave);
            }

            caveList.ForEach(c => Console.WriteLine($"{c.Name}"));

            var start = caveList.Single(c => c.IsStart);
            var routes = new List<string>();

            FindRoutesMod(start, "", false, ref routes);

            // routes.ForEach(r => 
            //     Console.WriteLine(r)
            // );
            Console.WriteLine();
            Console.WriteLine($"Routes: {routes.Count()}");
        }

        public static void FindRoutesMod(Cave current, string route, bool jockerUsed, ref List<string> routes)
        {
            //Console.WriteLine($"R: {route} <- {current.Name} ");
            if (current.IsEnd)
            {
                route += current.Name;
                routes.Add(route);
                return;
            }

            if (current.IsSmallCave && route.Contains($"{current.Name}"))
            {
                if (jockerUsed || current.IsStart) return;
                else jockerUsed = true;
            }

            route += current.Name + ",";

            foreach (var cave in current.Connected)
            {
                FindRoutesMod(cave, route, jockerUsed, ref routes);
            }
        }

        public static void FindRoutes(Cave current, string route, ref List<string> routes)
        {
            //Console.WriteLine($"R: {route} <- {current.Name} ");
            if (current.IsEnd)
            {
                route += current.Name;
                routes.Add(route);
                return;
            }

            if (current.IsSmallCave && route.Contains($"{current.Name}"))
            {
                return;
            }

            route += current.Name + ",";

            foreach (var cave in current.Connected)
            {
                FindRoutes(cave, route, ref routes);
            }
        }
    }
}
