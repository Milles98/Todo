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
            return await _todoContext.Todos.ToListAsync();
        }

        public async Task<Todo?> GetTodo(int id)
        {
            return await _todoContext.Todos.FindAsync(id);
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

        public async Task<Todo> DeleteTodo(int id)
        {
            var todo = await _todoContext.Todos.FindAsync(id) ?? throw new InvalidOperationException($"Todo with id {id} not found.");
            _todoContext.Remove(todo);
            await _todoContext.SaveChangesAsync();
            return todo;
        }
    }
}
