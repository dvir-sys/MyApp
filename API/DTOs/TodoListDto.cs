using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Entities;

namespace API.DTOs
{
    public class TodoListDto
    {
        public int id{ get; set; }
        public string url { get; set; }
        public ICollection<TaskItem> items{ get; set; }
        public string title { get; set; }
        public string description{ get; set; }
        public string color { get; set; }
        public string image{ get; set; }
    }
}