using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Dto;
using TodoApp.Models;
using TodoApp.Exceptions;

namespace TodoApp.Services
{
    public class TodoService
    {
        private TodoContext _todoContext;
        public TodoService(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task<List<Todo>> GetAll() => 
            await _todoContext.Todos.AsNoTracking().ToListAsync();

        public async Task<Todo?> GetTodo(int id) => 
            await _todoContext.Todos.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);

        public async Task<Todo> CreateTodoItem(TodoDto todoDto)
        {
            var desc = todoDto.Description?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(desc) || desc.Length > 200)
                throw new ValidationException("Description must be 1-200 chars without whitespace ");

            var todoItem = new Todo { Description = desc };

            _todoContext.Add(todoItem);
            await _todoContext.SaveChangesAsync();
            return todoItem;
        }

        public async Task<Todo?> UpdateTodo(int id, TodoDto dto)
        {
            var entity = await _todoContext.Todos.FindAsync(id)
                ?? throw new NotFoundException($"Todo {id} not found");

            var desc = dto.Description?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(desc) || desc.Length > 200)
                throw new ValidationException("Description must be 1-200 chars without whitespace ");

            entity.Description = desc;
            await _todoContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Todo?> PatchTodo(int id, TodoPatchDto dto)
        {
            var entity = await _todoContext.Todos.FindAsync(id)
                ?? throw new NotFoundException($"Todo {id} not found");

            if (dto.Description is null && dto.IsCompleted is null)
                throw new ValidationException("Atleast one field must be provided");

            if (dto.Description is not null)
            {
                var desc = dto.Description.Trim();
                if (string.IsNullOrWhiteSpace(desc) || desc.Length > 200)
                    throw new ValidationException("Description must be 1-200 chars without whitespace ");
                entity.Description = desc;
            }

            if (dto.IsCompleted.HasValue)
                entity.IsCompleted = dto.IsCompleted.Value;

            await _todoContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteTodo(int id)
        {
            var todo = await _todoContext.Todos.FindAsync(id);
            if (todo is null) return;

            _todoContext.Remove(todo);
            await _todoContext.SaveChangesAsync();
        }
    }
}
