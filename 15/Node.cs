using System;

namespace _15
{
    public class Node
    {
        public Node(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int? Distance { get; set; }
        public bool Visited { get; set; }
        public bool Final { get; set; }

        public void TrySetDistance(int newDistance, out bool first)
        {
            if (Distance == null) 
            {
                Distance = newDistance;
                first = true;
                return;
            }
            if (Distance > newDistance) 
            {
                first = false;
                Distance = newDistance;
                return;
            }
            first = false;
        }
    }
}