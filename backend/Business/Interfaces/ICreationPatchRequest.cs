using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICreationPatchRequest
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
