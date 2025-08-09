using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Dto;
using TodoApp.Models;

namespace TodoApp.Services
{
    public class TodoService
    {
        private TodoContext _todoContext;
        public TodoService(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task<List<Todo>> GetAll()
        {
            return await _todoContext.Todos.AsNoTracking().ToListAsync();
        }

        public async Task<Todo?> GetTodo(int id)
        {
            return await _todoContext.Todos.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Todo> CreateTodoItem(TodoDto todoDto)
        {
            var todoItem = new Todo
            {
                Description = todoDto.Description,
            };
            _todoContext.Add(todoItem);
            await _todoContext.SaveChangesAsync();
            return todoItem;
        }

        public async Task<Todo?> UpdateTodo(int id, TodoDto dto)
        {
            var entity = await _todoContext.Todos.FindAsync(id);
            if (entity is null) return null;

            entity.Description = dto.Description;

            await _todoContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteTodo(int id)
        {
            var todo = await _todoContext.Todos.FindAsync(id);
            if (todo is null)
                return false;

            _todoContext.Remove(todo);
            await _todoContext.SaveChangesAsync();
            return true;
        }
    }
}
