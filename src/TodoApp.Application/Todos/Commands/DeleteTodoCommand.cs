using MediatR;

namespace TodoApp.Application.Todos.Commands
{
    public record DeleteTodoCommand(int Id) : IRequest<Unit>;
}
