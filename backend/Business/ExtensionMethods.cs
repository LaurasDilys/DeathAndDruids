using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class ExtensionMethods
    {
        public static int Modifier(this int abilityScore) => Convert.ToInt32(Math.Floor(((float)abilityScore - 10) / 2));

        public static string ModifierText(this int abilityScore)
        {
            int modifier = abilityScore.Modifier();
            if (modifier > 0) return $"+{modifier}";
            return modifier.ToString();
        }

        public static int Between(this int value, int min, int max)
        {
            if (value < min)
            { value = min; }
            else if (value > max)
            { value = max; }
            return value;
        }
    }
}
