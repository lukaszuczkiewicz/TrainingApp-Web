using Domain.Repositories;
using PlainCQRS.Core.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Runner.Commands
{
    public class UpdateRunnerCommandHandler : ICommandHandlerAsync<UpdateRunnerCommand>
    {
        private readonly IWriteRepository<Domain.Runner> repository;

        public UpdateRunnerCommandHandler(IWriteRepository<Domain.Runner> repository)
        {
            this.repository = repository;
        }

        public Task HandleAsync(UpdateRunnerCommand command, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
