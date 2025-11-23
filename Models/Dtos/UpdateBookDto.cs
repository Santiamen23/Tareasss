using System.ComponentModel.DataAnnotations;

namespace BooksTW.Models.Dtos
{
    public record UpdateBookDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
