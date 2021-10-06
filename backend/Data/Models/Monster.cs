using Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Monster: CharacterDataModel
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public bool InCombat { get; set; }
        public bool InCreation { get; set; } // onOpen => true
    }
}
