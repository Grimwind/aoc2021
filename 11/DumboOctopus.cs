using System;

namespace _11
{
    public class DumboOctopus
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int EnergyLevel { get; private set; }
        public bool Flashed { get; private set; }
        public DumboOctopus(int initialEnergy, int x, int y)
        {
            EnergyLevel = initialEnergy;
            X = x;
            Y = y;
        }

        public bool Charge()
        {
            if (!Flashed)
            {
                EnergyLevel++;
            }

            if (EnergyLevel > 9 && Flashed == false)
            {
                Flashed = true;
                EnergyLevel = 0;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            if (Flashed)
            {
                Flashed = false;
                //EnergyLevel = 0;
            }
        }

        public override string ToString()
        {
            if (Flashed)
            {
                return $"({EnergyLevel})";
            }
            return " " + EnergyLevel.ToString() + " ";
        }
    }
}