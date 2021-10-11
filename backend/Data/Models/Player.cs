using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Initiative { get; set; }
        public string Type { get; set; }
        public int? CombatId { get; set; }
    }
}
