using System.Collections.Generic;

namespace API.Entities
{
    public class TodoList
    {
        public int Id{ get; set; }
        public string url { get; set; }
        public ICollection<TaskItem> tasks{ get; set; }
        public string title { get; set; }
        public string description{ get; set; }
        public string color { get; set; }
        public string image{ get; set; }
    }
}