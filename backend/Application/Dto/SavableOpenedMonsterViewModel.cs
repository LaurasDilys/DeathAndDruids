using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class SavableOpenedMonsterViewModel : OpenedMonsterViewModel
    {
        public SavableOpenedMonsterViewModel(int id, int? sourceId, bool saved) : base(id, sourceId)
        {
            Saved = saved;
        }

        public bool Saved { get; set; }
    }
}
