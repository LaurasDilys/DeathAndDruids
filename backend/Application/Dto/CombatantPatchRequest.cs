using Business.Interfaces;

namespace Application.Dto
{
    public class CombatantPatchRequest : CreationPatchRequest, ICombatantPatchRequest
    {
        public int Id { get; set; }
    }
}
