using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Caption { get; set; }
    }
}