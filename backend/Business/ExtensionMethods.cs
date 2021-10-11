using System;

namespace Business
{
    public static class ExtensionMethods
    {
        public static int Modifier(this int abilityScore) => Convert.ToInt32(Math.Floor(((float)abilityScore - 10) / 2));

        public static int Between(this int value, int min, int max)
        {
            if (value < min)
            { value = min; }
            else if (value > max)
            { value = max; }
            return value;
        }

        public static double Between(this double value, int min, int max)
        {
            if (value < min)
            { value = min; }
            else if (value > max)
            { value = max; }
            return value;
        }
    }
}
