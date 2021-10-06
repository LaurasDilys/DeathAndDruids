using Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class OpenedMonster: CharacterDataModel
    {
        [Key]
        public int Id { get; set; }
        public int? SourceId { get; set; }
        public bool Saved { get; set; } // onChange => false
    }
}
