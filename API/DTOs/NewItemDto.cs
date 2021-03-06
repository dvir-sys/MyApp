using System.ComponentModel.DataAnnotations;
using API.Entities;

namespace API.DTOs
{
    public class NewItemDto
    {
        [Required]
        public string Caption { get; set; }
        [Required]
        public int ListId { get; set; }
        public TodoList TodoList { get; set; }

    }
}