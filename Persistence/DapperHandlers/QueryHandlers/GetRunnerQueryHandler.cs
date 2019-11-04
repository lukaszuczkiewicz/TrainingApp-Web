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

namespace Persistence.DapperHandlers.QueryHandlers
{
    public class GetRunnerQueryHandler// : IQueryHandlerAsync<GetRunnerQuery, RunnerViewModel>
    {
        private readonly IDbConfigProvider dbConfigProvider;
        private readonly IHttpContextAccessor contextAccessor;

        public GetRunnerQueryHandler(IDbConfigProvider dbConfigProvider,
            IHttpContextAccessor contextAccessor)
        {
            this.dbConfigProvider = dbConfigProvider;
            this.contextAccessor = contextAccessor;
        }

        //public Task<RunnerViewModel> HandleAsync(GetRunnerQuery query, CancellationToken cancellationToken = default)
        //{
        //    var coachId = contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //    var sql = @"SELECT[Id],
        //                [FirstName],
        //                [LastName],
        //                [Email]
        //FROM[Core].[Runners]
        //WHERE[CoachId] = @coachId";
        //}
    }
}
