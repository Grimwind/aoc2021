using System;
using System.Diagnostics.CodeAnalysis;

namespace _5 {
    public class Point : IEquatable<Point>
    {
        public int X {get;set;}
        public int Y {get;set;}

        public Point (int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(Point vector)
        {
            X += vector.X;
            Y += vector.Y;
        }

        public Point Copy()
        {
            return new Point(X, Y);
        }

        public bool Equals([AllowNull] Point p)
        {
            if (p is null) return false;

            if (Object.ReferenceEquals(this, p)) return true;

            if (this.GetType() != p.GetType()) return false;

            return (X == p.X) && (Y == p.Y);
        }

        public override bool Equals(object obj) => this.Equals(obj as Point);
        public override int GetHashCode() => (X,Y).GetHashCode();

        public static bool operator ==(Point lhs, Point rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                {
                    return true;
                }
                return false;
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Point lhs, Point rhs) => !(lhs == rhs);
    }
}