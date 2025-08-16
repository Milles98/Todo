using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Abstractions
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAllAsync(CancellationToken ct = default);
        Task<Todo?> GetByIdAsync(int id, CancellationToken ct = default);
        Task AddAsync(Todo todo, CancellationToken ct = default);
        Task DeleteAsync(Todo todo, CancellationToken ct = default);
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
