using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ItemDto
    {
        [Required]
        public string Caption { get; set; }
    }
}