using MediatR;
using TodoApp.Application.Abstractions;
using TodoApp.Application.Exceptions;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Todos.Commands
{
    public sealed class UpdateTodoHandler : IRequestHandler<UpdateTodoCommand, Todo>
    {
        private readonly ITodoRepository _repo;
        public UpdateTodoHandler(ITodoRepository repo) => _repo = repo;

        public async Task<Todo> Handle(UpdateTodoCommand request, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(request.Id, ct)
                ?? throw new NotFoundException($"Todo {request.Id} not found");

            entity.Description = request.Dto.Description!.Trim();

            await _repo.SaveChangesAsync(ct);
            return entity;
        }
    }
}
