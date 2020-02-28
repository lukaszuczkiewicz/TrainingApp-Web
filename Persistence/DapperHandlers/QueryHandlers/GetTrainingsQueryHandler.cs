using Application.Queries.Training.GetTrainingsForUser;
using ApplicationQueries.Training;
using Dapper;
using Microsoft.AspNetCore.Http;
using Persistence.Abstractions;
using PlainCQRS.Core.Queries;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.DapperHandlers.QueryHandlers
{
    public class GetTrainingsQueryHandler: IQueryHandlerAsync<GetTrainingsQuery, IEnumerable<TrainingViewModel>>
    {
        private readonly IDbConfigProvider databaseProvider;
        private readonly IHttpContextAccessor httpContext;

        public GetTrainingsQueryHandler(
            IDbConfigProvider databaseProvider,
            IHttpContextAccessor httpContext)
        {
            this.databaseProvider = databaseProvider;
            this.httpContext = httpContext;
        }

        public async Task<IEnumerable<TrainingViewModel>> HandleAsync(GetTrainingsQuery query, CancellationToken cancellationToken = default)
        {
            var coachId = httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var sql = @"SELECT * FROM [Core].[Trainings]";

            using (var connection = new SqlConnection(databaseProvider.ConnectionStrings.DefaultConnection))
            {
                connection.Open();

                var trainings = await connection.QueryAsync<TrainingViewModel>
                    (sql);

                return await connection.QueryAsync<TrainingViewModel>(sql);
            }
        }
    }
}
