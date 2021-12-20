using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _13
{
    class Program
    {
        static void Main(string[] args)
        {

            var data = File.ReadAllLines("input.txt");

            var points = new List<Point>();
            var folds = new List<(string, int)>();
            for (int i = 0; i <= data.Length; i++)
            {
                if (data[i] == string.Empty)
                {
                    folds = data
                        .ToList()
                        .GetRange(i + 1, data.Count() - i - 1)
                        .Select(f => f.Split(' ')[2])
                        .Select(f => (f.Split('=')[0], int.Parse(f.Split('=')[1])))
                        .ToList();

                    break;
                }
                points.Add(new Point(
                    int.Parse(data[i].Split(',')[0]),
                    int.Parse(data[i].Split(',')[1])));
            }

            Console.WriteLine($"{points.Count()}");
            Fold(folds[0], ref points);
            Console.WriteLine($"{points.Count()}");
            // folds.ForEach(f => Console.WriteLine($"{f.Item1} => {f.Item2}"));


            // Draw(points);
            foreach (var fold in folds)
            {
                Fold(fold, ref points);

            }
            Draw(points);
        }

        public static void Draw(List<Point> points)
        {
            Console.WriteLine();
            for (int y = 0; y <= points.Max(p => p.Y); y++)
            {
                for (int x = 0; x <= points.Max(p => p.X); x++)
                {

                    if (points.Any(p => p.X == x && p.Y == y))
                    {
                        Console.Write("#");

                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine($"{points.Count()}");
        }

        public static void Fold((string, int) fold, ref List<Point> points)
        {
            if (fold.Item1 == "y")
            {
                FoldY(fold.Item2, ref points);
            }
            else
            {
                FoldX(fold.Item2, ref points);
            }

            points = points.Distinct().ToList();
        }

        public static void FoldY(int fold, ref List<Point> points)
        {
            foreach (var point in points)
            {
                if (point.Y > fold)
                {
                    var newY = ((point.Y - fold) * -1) + fold;
                    point.Y = newY;
                }
            }
        }
        public static void FoldX(int fold, ref List<Point> points)
        {
            foreach (var point in points)
            {
                if (point.X > fold)
                {
                    var newX = ((point.X - fold) * -1) + fold;
                    point.X = newX;
                }
            }
        }
    }
}
