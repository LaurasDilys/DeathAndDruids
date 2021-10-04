using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Monster
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Initiative { get; set; }
        public string Type { get; set; }
        public bool InCombat { get; set; }
        public bool InCreation { get; set; }
    }
}
