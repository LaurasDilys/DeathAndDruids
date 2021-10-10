using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CreationPatchRequest : ICreationPatchRequest
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
