namespace API.Entities
{
    public class TaskItem
    {
        public int Id{ get; set; }
        public string Caption { get; set; }
        public int ListId{ get; set; }
        public bool IsCompleted{ get; set; }
    }
}