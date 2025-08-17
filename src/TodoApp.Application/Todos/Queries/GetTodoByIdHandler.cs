using MediatR;
using TodoApp.Application.Abstractions;
using TodoApp.Application.Exceptions;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Todos.Queries
{
    public sealed class GetTodoByIdHandler : IRequestHandler<GetTodoByIdQuery, Todo>
    {
        private readonly ITodoRepository _repo;
        public GetTodoByIdHandler(ITodoRepository repo) => _repo = repo;

        public async Task<Todo> Handle(GetTodoByIdQuery request, CancellationToken ct)
        {
            return await _repo.GetByIdAsync(request.Id, ct)
                ?? throw new NotFoundException($"Todo {request.Id} not found");
        }
    }
}
