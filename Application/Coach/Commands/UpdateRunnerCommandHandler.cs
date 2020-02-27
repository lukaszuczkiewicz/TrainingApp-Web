using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using PlainCQRS.Core.Commands;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Coach.Commands
{
    public class UpdateRunnerCommandHandler : ICommandHandlerAsync<UpdateRunnerCommand>
    {
        private readonly IWriteRepository<Domain.Coach> repository;
        private readonly IHttpContextAccessor httpContext;

        public UpdateRunnerCommandHandler(IWriteRepository<Domain.Coach> repository,
            IHttpContextAccessor httpContext)
        {
            this.repository = repository;
            this.httpContext = httpContext;
        }

        public async Task HandleAsync(UpdateRunnerCommand command, CancellationToken cancellationToken = default)
        {
            Guid.TryParse(httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                out Guid coachId);

            var coach = await repository.GetByAsync(p => p.Id == coachId, new[] { "Runners" }, cancellationToken);

            if (coach.Equals(null))
                throw new ArgumentNullException($"There is no coach with Id {coachId}");

            var runnerFromDB = coach.Runners.Find(r => r.Id == command.Id);

            if (runnerFromDB == null)
                throw new ArgumentNullException($"No runner found");

            runnerFromDB.Update(command.FirstName, command.LastName, command.Email);

            await repository.SaveAsync(coach);
        }
    }
}
