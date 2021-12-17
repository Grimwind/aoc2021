using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            var school = File.ReadAllText("input.txt").Split(',')
                .Select(x => new Lanternfish(int.Parse(x)))
                .ToList();

            school = Lanternfish.Group(school);

            for(int day = 0; day < 256 ;day ++)
            {
                Console.WriteLine($"Day {day}");
                var newFishes = new List<Lanternfish>();
                foreach (var fish in school)
                {
                    var newFish = fish.NextDay();
                    if (newFish != null) newFishes.Add(newFish);
                }
                //school = Lanternfish.Group(school);
                school.AddRange(Lanternfish.Group(newFishes));
            }

            Console.WriteLine($"Count: {school.Sum(x => x.Size)}");
        }
    }
}
