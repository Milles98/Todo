using MediatR;
using TodoApp.Application.Dto;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Todos.Commands
{
    public record PatchTodoCommand(int Id, TodoPatchDto dto) : IRequest<Todo>;
}
