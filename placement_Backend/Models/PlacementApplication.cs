using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace placement_Backend.Models
{
    public class PlacementApplication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Description { get; set; }

        [ForeignKey(nameof(Placement))]
        public int PlacementId { get; set; }

        public Placement Placement { get; set; }


        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
