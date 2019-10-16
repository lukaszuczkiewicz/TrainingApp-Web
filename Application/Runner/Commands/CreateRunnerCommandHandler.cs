using Domain.Repositories;
using PlainCQRS.Core.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Runner.Commands
{
    public class CreateRunnerCommandHandler : ICommandHandlerAsync<CreateRunnerCommand>
    {
        private readonly IWriteRepository<Domain.Runner> repository;

        public CreateRunnerCommandHandler(IWriteRepository<Domain.Runner> repository)
        {
            this.repository = repository;
        }

        public  async Task HandleAsync(CreateRunnerCommand command, CancellationToken cancellationToken = default)
        {
            var runner = Domain.Runner.Create(
                firstName: command.FirstName,
                lastName: command.LastName,
                password: command.Password,
                login: command.Login,
                preSharedCode: command.PreSharedKey,
                email: command.Email
                );

           await repository.SaveAsync(runner);
        }
    }
}
