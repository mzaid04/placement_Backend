using System.ComponentModel.DataAnnotations;

namespace PlacementModels.Models
{
    public class UserDTO
    {

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Type { get; set; }
    }
}
