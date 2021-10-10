using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class OpenedMonsterViewModel : OpenedMonster
    {
        public OpenedMonsterViewModel(int id, int? sourceId, bool saved)
        {
            Id = id;
            SourceId = sourceId;
        }

        public string StrengthModifier { get; set; }
        public string DexterityModifier { get; set; }
        public string ConstitutionModifier { get; set; }
        public string IntelligenceModifier { get; set; }
        public string WisdomModifier { get; set; }
        public string CharismaModifier { get; set; }

        public string StrengthSavingThrow { get; set; }
        public string Athletics { get; set; }

        public string DexteritySavingThrow { get; set; }
        public string Acrobatics { get; set; }
        public string SleightOfHand { get; set; }
        public string Stealth { get; set; }

        public string ConstitutionSavingThrow { get; set; }

        public string IntelligenceSavingThrow { get; set; }
        public string Arcana { get; set; }
        public string History { get; set; }
        public string Investigation { get; set; }
        public string Nature { get; set; }
        public string Religion { get; set; }

        public string WisdomSavingThrow { get; set; }
        public string AnimalHandling { get; set; }
        public string Insight { get; set; }
        public string Medicine { get; set; }
        public string Perception { get; set; }
        public string Survival { get; set; }

        public string CharismaSavingThrow { get; set; }
        public string Deception { get; set; }
        public string Intimidation { get; set; }
        public string Performance { get; set; }
        public string Persuasion { get; set; }
    }
}
