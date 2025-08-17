using MediatR;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Todos.Queries
{
    public record GetTodoByIdQuery(int Id) : IRequest<Todo>;
}