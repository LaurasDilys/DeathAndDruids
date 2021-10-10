using Business.Interfaces;

namespace Application.Dto
{
    public class CreationPatchRequest : ICreationPatchRequest
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
