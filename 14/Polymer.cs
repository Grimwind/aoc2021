using System;
using System.Collections.Generic;
using System.Linq;

namespace _14
{
    public class Polymer
    {

        private Dictionary<char, long> elements;
        private Dictionary<string, long> pairs;

        private Polymer(Dictionary<char, long> _elements = null)
        {
            pairs = new Dictionary<string, long>();
            if (_elements is null)
            {
                elements = new Dictionary<char, long>();
            }
            else
            {
                elements = _elements.ToDictionary(e => e.Key, e => e.Value);
            }
        }

        public Polymer(string polymerString) : this()
        {
            for (int i = 0; i < polymerString.Length - 1; i++)
            {
                AddElement(polymerString[i]);

                var key = polymerString.Substring(i, 2);
                AddPair(key);
            }
            AddElement(polymerString[polymerString.Length-1]);
        }

        private void AddPair(string pair, long count = 1)
        {
            if (!pairs.ContainsKey(pair))
            {
                pairs.Add(pair, count);
            }
            else
            {
                pairs[pair] += count;
            }
        }

        private void AddElement(char element, long count = 1)
        {
            if (!elements.ContainsKey(element))
            {
                elements.Add(element, count);
            }
            else
            {
                elements[element] += count;
            }
        }

        public Polymer Grow(List<Transition> transitions)
        {
            var newPolymer = new Polymer(this.elements);

            foreach (var transition in transitions)
            {
                if (pairs.ContainsKey(transition.Base))
                {
                    var count = pairs[transition.Base];
                    newPolymer.AddElement(transition.Element, count);

                    // first pair
                    newPolymer.AddPair(transition.Pair1, count);

                    // second pair
                    newPolymer.AddPair(transition.Pair2, count);
                }
            }

            return newPolymer;
        }

        public long Analyze()
        {
            return elements.Max(e => e.Value) - elements.Min(e => e.Value);
        }
    }
}