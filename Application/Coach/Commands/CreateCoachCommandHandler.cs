using System.Threading;
using System.Threading.Tasks;
using Domain;
using Domain.Repositories;
using PlainCQRS.Core.Commands;

namespace Application.Coach.Commands
{
    public class CreateCoachCommandHandler: ICommandHandlerAsync<CreateCoachCommand>
    {
        private readonly IWriteRepository<Domain.Coach> repository;

        public CreateCoachCommandHandler(IWriteRepository<Domain.Coach> repository)
        {
            this.repository = repository;
        }

        public async Task HandleAsync(CreateCoachCommand command, CancellationToken cancellationToken = default)
        {
            var email = Email.Create(command.Email);

            var coach = Domain.Coach.Create(
                login: command.Login,
                password: command.Password,
                firstName: command.FirstName,
                lastName: command.LastName,
                preSharedKey: command.PreSharedKey,
                email: email);

            await repository.SaveAsync(coach);
        }
    }
}
