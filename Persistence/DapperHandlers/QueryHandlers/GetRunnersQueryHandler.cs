
using ApplicationQueries.Runners;
using Microsoft.AspNetCore.Http;
using Persistence.Abstractions;
using PlainCQRS.Core.Queries;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace Persistence.DapperHandlers.QueryHandlers
{
    public class GetRunnersQueryHandler : IQueryHandlerAsync<GetRunnersQuery, IEnumerable<RunnerViewModel>>
    {
        private readonly IDbConfigProvider databaseProvider;
        private readonly IHttpContextAccessor httpContext;

        public GetRunnersQueryHandler(
            IDbConfigProvider databaseProvider,
            IHttpContextAccessor httpContext)
        {
            this.databaseProvider = databaseProvider;
            this.httpContext = httpContext;
        }

        public async Task<IEnumerable<RunnerViewModel>> HandleAsync(GetRunnersQuery query, CancellationToken cancellationToken = default)
        {
            var coachId = httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var sql = @"SELECT [Id],
                        [FirstName],
                        [LastName],
                        [Email]
                    FROM [Core].[Runners]
                WHERE [CoachId] = @coachId";                       

            using (var connection = new SqlConnection(databaseProvider.ConnectionStrings.DefaultConnection))
            {
                connection.Open();

                var runners = await connection.QueryAsync<RunnerViewModel>
                    (sql, new { coachId });

                return await connection.QueryAsync<RunnerViewModel>(sql, new { coachId });
            }
        }
    
    }
}
