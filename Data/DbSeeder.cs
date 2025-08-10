using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class DbSeeder
    {
        public static async Task SeedAsync(TodoContext context)
        {
            if (await context.Todos.AnyAsync())
                return;

            context.Todos.AddRange(
                new Todo { Description = "Buy Game", IsCompleted = true, CreatedAt = DateTime.UtcNow.AddMinutes(-30)},
                new Todo { Description = "Buy Food", IsCompleted = false, CreatedAt = DateTime.UtcNow.AddMinutes(5)},
                new Todo { Description = "Buy Coca Cola", IsCompleted = false, CreatedAt = DateTime.UtcNow.AddMinutes(45)}
                );

            await context.SaveChangesAsync();
        }
    }
}
