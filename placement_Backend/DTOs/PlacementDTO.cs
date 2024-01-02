using System.ComponentModel.DataAnnotations;

namespace placement_Backend.DTOs
{
    public class PlacementDTO
    {

        [Required(ErrorMessage = "Title is required.")]
        public string? Title { get; set; }



        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }

    }
}
