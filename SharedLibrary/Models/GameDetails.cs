using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Models
{
    public class GameDetails
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Genre field is required .")]
        [MinLength(1, ErrorMessage = "Name is Required")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "The Genre field is required .")]
        public string? GenreId { get; set; }
        [Range(1, 100, ErrorMessage = "The Price field is required and between 1 to 100.")]
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
