using System;
using System.Collections.Generic;

namespace _12
{
    public class Cave
    {
        public string Name { get; set; }
        public bool IsSmallCave { get; set; }
        public List<Cave> Connected { get; set; }

        public bool IsStart { get; set; }
        public bool IsEnd { get; set; }

        public Cave(string name)
        {
            Name = name;
            if (name == name.ToLower())
            {
                IsSmallCave = true;
            }
            Connected = new List<Cave>();

            if (name == "start")
            {
                IsStart = true;
            }

            if (name == "end")
            {
                IsEnd = true;
            }
        }

        public void Connect(Cave cave)
        {
            Connected.Add(cave);
        }
    }
}