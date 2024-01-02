using System.ComponentModel.DataAnnotations;

namespace placement_Backend.Models
{
    public class Placement
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public string? Title { get; set; }


        [Required]
        public string? Description { get; set; }


        public PlacementApplication PlacementApplication { get; set; }
    }
}
