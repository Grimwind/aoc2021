using System;
using System.Linq;
using System.Collections.Generic;

namespace _6 {
    
    public class Lanternfish {

        

        public Lanternfish(int initialTimer, long size = 1)
        {
            Size = size;
            Timer = initialTimer;
        }
        public long Size {get; private set;}
        public int Timer { get; private set; }

        public Lanternfish NextDay()
        {
            if (Timer == 0)
            {
                Timer = 6;
                return new Lanternfish(8, Size);
            }
            Timer--;

            return null;
        }

        public static List<Lanternfish> Group(List<Lanternfish> school)
        {
            var result = school.GroupBy(x => x.Timer)
                .Select(x => new Lanternfish (x.Key, x.Sum(f => f.Size)))
                .ToList();

                return result;
        }
    }
}