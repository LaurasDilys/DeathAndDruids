using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICombatantPatchRequest
    {
        int Id { get; set; }
        string Name { get; set; }
        string Value { get; set; }
    }
}
