using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string Route { get; set; }
        public int? SelectedTab { get; set; }
    }
}
