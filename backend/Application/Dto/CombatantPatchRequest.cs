using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CombatantPatchRequest : CreationPatchRequest, ICombatantPatchRequest
    {
        public int Id { get; set; }
    }
}
