using Microsoft.EntityFrameworkCore;
using System;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }
        public DbSet<Todo> Todos { get; set; }
    }
}
