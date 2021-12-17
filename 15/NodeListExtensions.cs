using System;
using System.Linq;
using System.Collections.Generic;

namespace _15
{
    public static class NodeListExtensions
    {
        public static Node Get(this List<Node> nodes, int x, int y)
        {
            return nodes.Single(n => n.X == x && n.Y == y);
        }
    }
}