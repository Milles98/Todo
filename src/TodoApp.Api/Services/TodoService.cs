using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Abstractions;
using TodoApp.Domain.Entities;
using TodoApp.Dto;
using TodoApp.Exceptions;
using TodoApp.Infrastructure;

namespace TodoApp.Services
{
    public class TodoService
    {
        private readonly ITodoRepository _repo;
        public TodoService(ITodoRepository repo) => _repo = repo;

        public Task<List<Todo>> GetAllAsync(CancellationToken ct = default)
            => _repo.GetAllAsync(ct);

        public async Task<Todo> GetAsync(int id, CancellationToken ct = default)
        {
            var todo = await _repo.GetByIdAsync(id, ct);
            return todo ?? throw new NotFoundException($"Todo {id} not found");
        }

        public async Task<Todo> CreateAsync(string description, CancellationToken ct = default)
        {
            var todo = new Todo { Description = description, IsCompleted = false, CreatedAt = DateTime.UtcNow };
            await _repo.AddAsync(todo, ct);
            await _repo.SaveChangesAsync(ct);
            return todo;
        }

        public async Task<Todo> UpdateTodo(int id, TodoDto dto, CancellationToken ct = default)
        {
            var entity = await _repo.GetByIdAsync(id, ct)
                ?? throw new NotFoundException($"Todo {id} not found");

            entity.Description = dto.Description.Trim();
            await _repo.SaveChangesAsync(ct);
            return entity;
        }

        public async Task<Todo> PatchTodo(int id, TodoPatchDto dto, CancellationToken ct = default)
        {
            var entity = await _repo.GetByIdAsync(id, ct)
                ?? throw new NotFoundException($"Todo {id} not found");

            if (dto.Description is not null)
                entity.Description = dto.Description.Trim();
                
            if (dto.IsCompleted is not null)
                entity.IsCompleted = dto.IsCompleted.Value;

            await _repo.SaveChangesAsync(ct);
            return entity;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var todo = await _repo.GetByIdAsync(id, ct);
            if (todo is null) return false;
            await _repo.DeleteAsync(todo, ct);
            await _repo.SaveChangesAsync(ct);
            return true;
        }
    }
}
