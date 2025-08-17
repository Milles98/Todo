using MediatR;
using TodoApp.Application.Abstractions;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Todos.Commands
{
    public sealed class CreateTodoHandler : IRequestHandler<CreateTodoCommand, Todo>
    {
        private readonly ITodoRepository _repo;
        public CreateTodoHandler(ITodoRepository repo) => _repo = repo;

        public async Task<Todo> Handle(CreateTodoCommand request, CancellationToken ct)
        {
            var todo = new Todo
            {
                Description = request.description.Trim(),
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow
            };

            await _repo.AddAsync(todo, ct);
            await _repo.SaveChangesAsync(ct);
            return todo;
        }
    }
}
