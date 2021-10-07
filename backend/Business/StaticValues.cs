using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class StaticValues
    {
        public static int MinCR { get; } = 0;
        public static int MaxCR { get; } = 30;

        public static int MinScore { get; } = 0;
        public static int MaxScore { get; } = 30;

        public static int InitialAbilityScoreValue { get; set; } = 10;

        public static int ProfBonusFromCR(double cr)
        {
            int prof = 0;

            if (cr < 5) { prof = 2; }
            else if (cr >= 5 && cr < 9) { prof = 3; }
            else if (cr >= 9 && cr < 13) { prof = 4; }
            else if (cr >= 13 && cr < 17) { prof = 5; }
            else if (cr >= 17 && cr < 21) { prof = 6; }
            else if (cr >= 21 && cr < 25) { prof = 7; }
            else if (cr >= 25 && cr < 29) { prof = 8; }
            else if (cr >= 29) { prof = 9; }

            return prof;
        }
    }
}
