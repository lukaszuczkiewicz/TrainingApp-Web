using Domain.Repositories;
using PlainCQRS.Core.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Coach.Commands
{
    public class CreateRunnerCommandHandler : ICommandHandlerAsync<CreateRunnerCommand>
    {
        private readonly IWriteRepository<Domain.Coach> repository;

        public CreateRunnerCommandHandler(IWriteRepository<Domain.Coach> repository)
        {
            this.repository = repository;
        }

        public Task HandleAsync(CreateRunnerCommand command, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
