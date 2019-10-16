using Domain.SharedKernel;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IWriteRepository<T> where T : Entity
    {
        Task<T> GetByAsync(Expression<Func<T, bool>> predictate, string[] includes, CancellationToken cancellationToken = default);
        Task SaveAsync(T entity, CancellationToken cancellationToken = default);
    }
}
