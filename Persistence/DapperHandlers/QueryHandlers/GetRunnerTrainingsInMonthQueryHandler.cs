using Application.Queries.Training.GetTrainingsForUser;
using Microsoft.AspNetCore.Http;
using Persistence.Abstractions;
using PlainCQRS.Core.Queries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.DapperHandlers.QueryHandlers
{
    public class GetRunnerTrainingsInMonthQueryHandler //: IQueryHandlerAsync<GetRunnerTrainingsInMonth, TrainingViewModel>
    {
        //private readonly IDbConfigProvider databaseProvider;
        //private readonly IHttpContextAccessor httpContext;

        //public GetRunnerTrainingsInMonthQueryHandler (
        //    IDbConfigProvider databaseProvider,
        //    IHttpContextAccessor httpContext)
        //{
        //    this.databaseProvider = databaseProvider;
        //    this.httpContext = httpContext;
        //}

        //public async Task<IEnumerable<RunnerViewModel>> HandleAsync(GetRunnersQuery query, CancellationToken cancellationToken = default)
        //{
        //    var coachId = httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //    var sql = @"SELECT [Id],
        //                [FirstName],
        //                [LastName],
        //                [Email]
        //            FROM [Core].[Runners]
        //        WHERE [CoachId] = @coachId";

        //    using (var connection = new SqlConnection(databaseProvider.ConnectionStrings.DefaultConnection))
        //    {
        //        connection.Open();

        //        var runners = await connection.QueryAsync<RunnerViewModel>
        //            (sql, new { coachId });

        //        return await connection.QueryAsync<RunnerViewModel>(sql, new { coachId });
        //    }
        //}
    }
}
