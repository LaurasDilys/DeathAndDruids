using Business.Models;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class SavableOpenedMonster : FlatCreature
    {
        [Key]
        public int Id { get; set; }
        public int? SourceId { get; set; }
        public bool Saved { get; set; }
    }
}
