using Business.Models;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Monster : FlatCreature
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public bool InCombat { get; set; }
        public bool InCreation { get; set; }
    }
}
