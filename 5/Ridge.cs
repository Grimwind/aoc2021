using System;
using System.Collections;
using System.Collections.Generic;

namespace _5
{
    public class Ridge : IEnumerable
    {
        public Point Start { get; set; }
        public Point End { get; set; }
        public bool IsHorizontal => Vector.Y == 0;
        public bool IsVertical => Vector.X == 0;
        public Point Vector { get; set; }

        private class RidgeEnumerator : IEnumerator
        {
            private readonly Ridge _ridge;
            private Point _current;

            public RidgeEnumerator(Ridge ridge)
            {
                _ridge = ridge;
                _current = null;
            }

            public object Current
            {
                get {
                    if (_current == null) throw new InvalidOperationException();
                    return _current;
                }
            }

            public bool MoveNext()
            {
                if (_current == null)
                {
                    _current = _ridge.Start.Copy();
                    return true;
                }
                if (_current == _ridge.End) return false;

                _current.Move(_ridge.Vector);
                return true;
            }

            public void Reset()
            {
                _current = null;
            }
        }

        public Ridge(string dataRow)
        {
            Parse(dataRow);
        }

        private void Parse(string dataRow)
        {
            var spl = dataRow.Split("->", StringSplitOptions.None);
            Start = ParsePoint(spl[0]);
            End = ParsePoint(spl[1]);

            Vector = new Point(
                End.X - Start.X == 0 ? 0 : (End.X - Start.X) / Math.Abs(End.X - Start.X),
                End.Y - Start.Y == 0 ? 0 : (End.Y - Start.Y) / Math.Abs(End.Y - Start.Y));
        }

        private static Point ParsePoint(string data)
        {
            var spl = data.Split(',');
            var result = new Point(int.Parse(spl[0]), int.Parse(spl[1]));

            return result;
        }

        public IEnumerator GetEnumerator()
        {
            return new RidgeEnumerator(this);
        }
        
    }
}