using ApplicationQueries.Runners;
using ApplicationQueries.SharedViewModels;
using Persistence.Abstractions;
using PlainCQRS.Core.Queries;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace Persistence.DapperHandlers.QueryHandlers
{
    public class GetCoachesQueryHandler : IQueryHandlerAsync<GetCoachesQuery, List<CoachWithEmailViewModel>>
    {
        private readonly IDbConfigProvider databaseProvider;

        public GetCoachesQueryHandler(IDbConfigProvider databaseProvider)
        {
            this.databaseProvider = databaseProvider;
        }

        public async Task<List<CoachWithEmailViewModel>> HandleAsync(GetCoachesQuery query, CancellationToken cancellationToken = default)
        {
            var sql = @"SELECT Id, Email FROM Core.Coaches";

            using (var connection = new SqlConnection(databaseProvider.ConnectionStrings.DefaultConnection))
            {
                await connection.OpenAsync();

                var result = await connection.QueryAsync<CoachWithEmailViewModel>(sql);

                return result.ToList();
            }
        }
    }
}
