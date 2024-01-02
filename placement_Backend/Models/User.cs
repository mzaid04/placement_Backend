using System.ComponentModel.DataAnnotations;

namespace placement_Backend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }


        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Type { get; set; }


        public PlacementApplication PlacementApplication { get; set; }
    }
}
