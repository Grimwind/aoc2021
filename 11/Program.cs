using System;
using System.IO;
using System.Linq;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = File.ReadAllLines("input.txt").CreateMap<DumboOctopus>(
                ((v, x, y) => new DumboOctopus(v, x, y))
            );

            var octopusCount = map.MAX_X<DumboOctopus>() * map.MAX_Y<DumboOctopus>();

            bool cont = true;
            int i = 1;
            while (cont)
            {
                map.ForEach<DumboOctopus>(oc =>
                {
                    if (oc.Charge())
                    {
                        Propagate(oc, map);
                    }
                });

                // Console.WriteLine($"Step {i}");
                // map.Draw<DumboOctopus>();

                var flashesCount = 0;
                map.ForEach<DumboOctopus>(oc =>
                {
                    if (oc.Flashed)
                        flashesCount++;
                    oc.Reset();
                });

                Console.WriteLine($"Step {i}: {flashesCount}/{octopusCount} Flashed");

                if (flashesCount == octopusCount)
                    cont = false;
                i++;
            }
        }

        static void Propagate(DumboOctopus oc, DumboOctopus[,] map)
        {
            for (int x = oc.X - 1; x <= oc.X + 1; x++)
            {
                if (x < 0 || x > map.MAX_X<DumboOctopus>() - 1) continue;
                for (int y = oc.Y - 1; y <= oc.Y + 1; y++)
                {
                    if (y < 0 || y > map.MAX_Y<DumboOctopus>() - 1) continue;

                    if (!map[x, y].Flashed)
                    {
                        if (map[x, y].Charge())
                        {
                            Propagate(map[x, y], map);
                        }
                    }
                }
            }
        }

        public static void First()
        {
            var map = File.ReadAllLines("input.txt").CreateMap<DumboOctopus>(
                ((v, x, y) => new DumboOctopus(v, x, y))
            );

            map.Draw<DumboOctopus>();

            int flashesCount = 0;
            for (int i = 1; i <= 100; i++)
            {
                map.ForEach<DumboOctopus>(oc =>
                {
                    if (oc.Charge())
                    {
                        Propagate(oc, map);
                    }
                });
                // Console.WriteLine($"Step {i}");
                // map.Draw<DumboOctopus>();

                map.ForEach<DumboOctopus>(oc =>
                {
                    if (oc.Flashed)
                        flashesCount++;
                    oc.Reset();
                });

            }

            flashesCount.Show("Count: ");
        }
    }
}
