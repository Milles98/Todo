namespace TodoApp.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
