using System.ComponentModel.DataAnnotations;

namespace TareaTecWeb.Models.Dtos
{
    public record CreateBookDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
