﻿namespace TodoApp.Domain.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
