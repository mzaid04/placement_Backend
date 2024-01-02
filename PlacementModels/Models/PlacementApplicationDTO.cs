using System.ComponentModel.DataAnnotations;

namespace PlacementModels.Models
{
    public class PlacementApplicationDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int PlacementId { get; set; }
    }
}
