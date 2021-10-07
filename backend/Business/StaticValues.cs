using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class StaticValues
    {
        public static int MinLevel { get; } = 1;
        public static int MaxLevel { get; } = 20;

        public static int MinScore { get; } = 0;
        public static int MaxScore { get; } = 30;

        public static int InitialAbilityScoreValue { get; set; } = 10;


        // Level, Experience Points
        public static Dictionary<int, int> XPfromLvl { get; set; } = new Dictionary<int, int>()
        {
            { 1, 0 },
            { 2, 300 },
            { 3, 900 },
            { 4, 2700 },
            { 5, 6500 },
            { 6, 14000 },
            { 7, 23000 },
            { 8, 34000 },
            { 9, 48000 },
            { 10, 64000 },
            { 11, 85000 },
            { 12, 100000 },
            { 13, 120000 },
            { 14, 140000 },
            { 15, 165000 },
            { 16, 195000 },
            { 17, 225000 },
            { 18, 265000 },
            { 19, 305000 },
            { 20, 355000 },
        };

        public static int ConvertToLvl(this int XP)
        {
            int level = 0;

            if (XP >= 0 && XP < 300) { level = 1; }
            else if (XP >= 300 && XP < 900) { level = 2; }
            else if (XP >= 900 && XP < 2700) { level = 3; }
            else if (XP >= 2700 && XP < 6500) { level = 4; }
            else if (XP >= 6500 && XP < 14000) { level = 5; }
            else if (XP >= 14000 && XP < 23000) { level = 6; }
            else if (XP >= 23000 && XP < 34000) { level = 7; }
            else if (XP >= 34000 && XP < 48000) { level = 8; }
            else if (XP >= 48000 && XP < 64000) { level = 9; }
            else if (XP >= 64000 && XP < 85000) { level = 10; }
            else if (XP >= 85000 && XP < 100000) { level = 11; }
            else if (XP >= 100000 && XP < 120000) { level = 12; }
            else if (XP >= 120000 && XP < 140000) { level = 13; }
            else if (XP >= 140000 && XP < 165000) { level = 14; }
            else if (XP >= 165000 && XP < 195000) { level = 15; }
            else if (XP >= 195000 && XP < 225000) { level = 16; }
            else if (XP >= 225000 && XP < 265000) { level = 17; }
            else if (XP >= 265000 && XP < 305000) { level = 18; }
            else if (XP >= 305000 && XP < 355000) { level = 19; }
            else if (XP >= 355000) { level = 20; }

            return level;
        }

        public static Dictionary<int, int> ProfBonusFromLvl { get; set; } = new Dictionary<int, int>()
        {
            { 1, 2 },
            { 2, 2 },
            { 3, 2 },
            { 4, 2 },
            { 5, 3 },
            { 6, 3 },
            { 7, 3 },
            { 8, 3 },
            { 9, 4 },
            { 10, 4 },
            { 11, 4 },
            { 12, 4 },
            { 13, 5 },
            { 14, 5 },
            { 15, 5 },
            { 16, 5 },
            { 17, 6 },
            { 18, 6 },
            { 19, 6 },
            { 20, 6 },
        };
    }
}
