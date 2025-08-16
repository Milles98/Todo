using Microsoft.EntityFrameworkCore;
using System;
using TodoApp.Domain.Entities;

namespace TodoApp.Infrastructure
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }
        public DbSet<Todo> Todos { get; set; }
    }
}
