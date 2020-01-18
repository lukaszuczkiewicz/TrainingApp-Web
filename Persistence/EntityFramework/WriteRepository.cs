using Domain;
using Domain.Repositories;
using Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.EntityFramowork
{
    public class WriteRepository<T> : IWriteRepository<T> where T : AggregateRoot
    {
        private readonly DataBaseContext dataBaseContext;

        public WriteRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public async Task<T> GetByAsync(Expression<Func<T, bool>> predictate, string[] includes,  CancellationToken cancellationToken = default)
        {
            var query = dataBaseContext
                .Set<T>()
                .Where(predictate);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(cancellationToken);
        }


        public async Task SaveAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (Exist(entity))
            {
                dataBaseContext.Update(entity);
                await dataBaseContext.SaveChangesAsync(cancellationToken);
            }

            else
            {
                dataBaseContext.Add(entity);
                await dataBaseContext.SaveChangesAsync(cancellationToken);
            }
        }

        private bool Exist(T entity)
        {
            return dataBaseContext.ChangeTracker
                .Entries<T>()
                .Any(e => e.Entity.Id == entity.Id);
        }
    }
}
