using System;

namespace _14
{
    public class Transition
    {
        public string Base { get; private set; }
        public string Pair1 { get; private set; }
        public string Pair2 { get; private set; }
        public char Element { get; private set; }
        public Transition(string transitionString)
        {
            var pair = transitionString.Split(" -> ")[0];
            Base = pair;
            var element = transitionString.Split(" -> ")[1];
            Element = element[0];

            Pair1 = $"{Base[0]}{Element}";
            Pair2 = $"{Element}{Base[1]}";
        }
    }
}