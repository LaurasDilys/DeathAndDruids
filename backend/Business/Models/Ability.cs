using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Ability
    {
        private int score;
        public int Score
        {
            get { return score; }
            set
            {
                score = value.Between(StaticValues.MinScore, StaticValues.MaxScore);
                Modifier = score.Modifier();
                UpdateSavingThrowAndSkills();
            }
        }


        private int modfier;
        public int Modifier
        {
            get { return modfier; }
            set { modfier = value;
                //OnPropertyChanged();
                }
        }


        public SavingThrow SavingThrow { get; set; } = new SavingThrow();
        public List<Skill> Skills { get; set; } = new List<Skill>();


        private void UpdateSavingThrowAndSkills()
        {
            SavingThrow.CorrespondingAbilityModifier = Modifier;
            foreach (Skill skill in Skills) skill.CorrespondingAbilityModifier = Modifier;
        }
    }
}
