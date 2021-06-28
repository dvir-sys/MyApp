using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class NewItemDto
    {
        [Required]
        public string Caption { get; set; }
        [Required]
        public int ListId { get; set; }

    }
}