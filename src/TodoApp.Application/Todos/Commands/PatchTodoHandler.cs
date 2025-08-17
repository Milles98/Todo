using MediatR;
using TodoApp.Application.Abstractions;
using TodoApp.Application.Exceptions;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Todos.Commands
{
    public sealed class PatchTodoHandler : IRequestHandler<PatchTodoCommand, Todo>
    {
        private readonly ITodoRepository _repo;
        public PatchTodoHandler(ITodoRepository repo) => _repo = repo;

        public async Task<Todo> Handle(PatchTodoCommand request, CancellationToken ct)
        {
            var e = await _repo.GetByIdAsync(request.Id)
                ?? throw new NotFoundException($"Todo {request.Id} not found");

            if (request.dto.Description is not null)
                e.Description = request.dto.Description.Trim();

            if (request.dto.IsCompleted is not null)
                e.IsCompleted = request.dto.IsCompleted.Value;

            await _repo.SaveChangesAsync(ct);
            return e;
        }
    }
}
