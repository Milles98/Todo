using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Abstractions;
using TodoApp.Domain.Entities;
using TodoApp.Infrastructure.Data;

namespace TodoApp.Infrastructure.Repositories
{
    public sealed class EfTodoRepository : ITodoRepository
    {
        private readonly TodoContext _db;
        public EfTodoRepository(TodoContext db) => _db = db;

        public Task<List<Todo>> GetAllAsync(CancellationToken ct = default) => 
            _db.Todos.AsNoTracking().ToListAsync(ct);

        public Task<Todo?> GetByIdAsync(int id, CancellationToken ct = default) =>
            _db.Todos.FindAsync(new object?[] { id }, ct).AsTask();

        public async Task AddAsync(Todo todo, CancellationToken ct = default) =>
            await _db.Todos.AddAsync(todo, ct);

        public Task DeleteAsync(Todo todo, CancellationToken ct = default)
        {
            _db.Todos.Remove(todo);
            return Task.CompletedTask;
        }

        public Task<int> SaveChangesAsync(CancellationToken ct = default) =>
            _db.SaveChangesAsync(ct);
    }
}
