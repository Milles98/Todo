using MediatR;
using TodoApp.Application.Abstractions;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Todos.Queries
{
    public sealed class GetTodosHandler : IRequestHandler<GetTodosQuery, List<Todo>>
    {
        private readonly ITodoRepository _repo;
        public GetTodosHandler(ITodoRepository repo) => _repo = repo;

        public async Task<List<Todo>> Handle(GetTodosQuery request, CancellationToken ct)
            => await _repo.GetAllAsync(ct);
    }
}
