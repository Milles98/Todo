using MediatR;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Todos.Commands
{
    public record CreateTodoCommand(string description) : IRequest<Todo>;
}
