using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using PlainCQRS.Core.Commands;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Coach.Commands
{
    public class DeleteRunnerCommandHandler : ICommandHandlerAsync<DeleteRunnerCommand>
    {
        private readonly IWriteRepository<Domain.Coach> repository;
        private readonly IHttpContextAccessor httpContext;

        public DeleteRunnerCommandHandler(IWriteRepository<Domain.Coach> repository,
            IHttpContextAccessor httpContext)
        {
            this.repository = repository;
            this.httpContext = httpContext;
        }

        public async Task HandleAsync(DeleteRunnerCommand command, CancellationToken cancellationToken = default)
        {
            Guid.TryParse(httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                out Guid coachId);

            var coach = await repository.GetByAsync(p => p.Id == coachId, new[] { "Runners" }, cancellationToken);

            if (coach.Equals(null))
                throw new ArgumentNullException($"There is no coach with Id {coachId}");

            var runnerIndex = coach.Runners.FindIndex(r => r.Id == command.Id);

            if (runnerIndex.Equals(null) || runnerIndex < 0)
                throw new ArgumentNullException($"There is no runner with Id {command.Id}");

            coach.Runners.RemoveAt(runnerIndex);

            await repository.SaveAsync(coach);
        }
    }
}
