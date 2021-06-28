using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class EditItemDto
    {
        [Required]
        public int Id{ get; set; }
        public string Caption { get; set; }
        public int ListId { get; set; }
        public bool IsCompleted{ get; set; }
    }
}