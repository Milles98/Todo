using MediatR;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Todos.Queries
{
    public record GetTodosQuery : IRequest<List<Todo>>;
}
