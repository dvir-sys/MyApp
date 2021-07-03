using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ListItemDto
    {
        [Required]
        public int Id{ get; set; }
        [Required]
        public string Caption { get; set; }
        public int ListId { get; set; }
        [Required]
        public bool IsCompleted{ get; set; }
    }
}