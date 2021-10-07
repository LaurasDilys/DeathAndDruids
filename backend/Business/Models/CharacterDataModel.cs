using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class CharacterDataModel // FlatCreature
    {
        public string Name { get; set; }
        public int Initiative { get; set; }

        public int ProficiencyBonus { get; set; }

        public int Strength { get; set; }

        public bool StrengthSavingThrowProficiency { get; set; }
        public bool AthleticsProficiency { get; set; }
    }
}
