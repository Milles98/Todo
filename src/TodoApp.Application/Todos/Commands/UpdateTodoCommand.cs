using MediatR;
using TodoApp.Application.Dto;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Todos.Commands
{
    public record UpdateTodoCommand(int Id, TodoDto Dto) : IRequest<Todo>;
}
