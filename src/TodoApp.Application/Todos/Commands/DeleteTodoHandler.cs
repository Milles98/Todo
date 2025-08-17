using MediatR;
using TodoApp.Application.Abstractions;
using TodoApp.Application.Exceptions;

namespace TodoApp.Application.Todos.Commands
{
    public sealed class DeleteTodoHandler : IRequestHandler<DeleteTodoCommand, Unit>
    {
        private readonly ITodoRepository _repo;
        public DeleteTodoHandler(ITodoRepository repo) => _repo = repo;

        public async Task<Unit> Handle(DeleteTodoCommand request, CancellationToken ct)
        {
            var e = await _repo.GetByIdAsync(request.Id, ct)
                ?? throw new NotFoundException($"Todo {request.Id} not found");

            await _repo.DeleteAsync(e, ct);
            await _repo.SaveChangesAsync(ct);
            return Unit.Value;
        }
    }
}
