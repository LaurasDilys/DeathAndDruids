using System.Collections.Generic;

namespace Application.Dto
{
    public class CombatRequest
    {
        public IEnumerable<CombatantRequest> Request { get; set; }
    }
}
