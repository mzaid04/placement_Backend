
using System.ComponentModel.DataAnnotations;

namespace PlacementModels.Models
{
    internal class PlacementDTO
    {
        [Required(ErrorMessage = "Title is required.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }
    }
}
