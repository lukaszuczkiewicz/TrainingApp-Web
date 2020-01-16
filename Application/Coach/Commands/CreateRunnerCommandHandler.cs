using Domain;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using PlainCQRS.Core.Commands;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Coach.Commands
{
    public class CreateRunnerCommandHandler : ICommandHandlerAsync<CreateRunnerCommand>
    {
        private readonly IWriteRepository<Domain.Coach> repository;
        private readonly IHttpContextAccessor httpContext;

        public CreateRunnerCommandHandler(IWriteRepository<Domain.Coach> repository, 
            IHttpContextAccessor httpContext)
        {
            this.repository = repository;
            this.httpContext = httpContext;
        }

        public async Task HandleAsync(CreateRunnerCommand command, CancellationToken cancellationToken = default)
        {
            Guid.TryParse(httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                out Guid coachId);

            var coach = await repository.GetByAsync(p => p.Id == coachId, new[] { "Runners" }, cancellationToken);

            if (coach.Equals(null))
                throw new ArgumentNullException($"There is no coach with Id {coachId}");

            var runner = Runner.Create(
                command.FirstName,
                command.LastName,
                Email.Create(command.Email)
                );

            coach.AddRunner(runner);

            await repository.SaveAsync(coach);
        }
    }
}
