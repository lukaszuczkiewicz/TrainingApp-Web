using Application.Queries.Training.GetTrainingsForUser;
using ApplicationQueries.Training;
using Dapper;
using Microsoft.AspNetCore.Http;
using Persistence.Abstractions;
using PlainCQRS.Core.Queries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.DapperHandlers.QueryHandlers
{
    public class GetTrainingsQueryHandler: IQueryHandlerAsync<GetTrainingsQuery, IEnumerable<TrainingToReturnViewModel>>
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

        public async Task<IEnumerable<TrainingToReturnViewModel>> HandleAsync(GetTrainingsQuery query, CancellationToken cancellationToken = default)
        {
            var coachId = httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var sql = @"SELECT
                        [Core].[Trainings].[Id],
                        [Core].[Trainings].[RunnerId],
                        [Core].[Trainings].[DateToDo],
                        [Core].[Trainings].[Created],
                        [Core].[Trainings].[IsDone],
                        [dbo].[TraningDetails].[Details],
                        [dbo].[TraningDetails].[Comment],
                        [Core].[Runners].[FirstName],
                        [Core].[Runners].[LastName],
                        [Core].[Runners].[CoachId]
                        FROM (([Core].[Trainings]
                        INNER JOIN [dbo].[TraningDetails]
                        ON [Core].[Trainings].[TraningDetailsId] = [dbo].[TraningDetails].[Id])
                        INNER JOIN [Core].[Runners]
                        ON [Core].[Trainings].[RunnerId] = [Core].[Runners].[Id])
                        WHERE [Core].[Runners].[CoachId] = @coachId";

            using (var connection = new SqlConnection(databaseProvider.ConnectionStrings.DefaultConnection))
            {
                connection.Open();

                return await connection.QueryAsync<TrainingToReturnViewModel>(sql, new { coachId });
            }
        }
    }
}
