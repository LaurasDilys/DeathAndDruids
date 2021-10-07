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
            Saved = saved;
        }

        public string StrengthModifier { get; set; }

        public string StrengthSavingThrow { get; set; }
        public string Athletics { get; set; }
    }
}
