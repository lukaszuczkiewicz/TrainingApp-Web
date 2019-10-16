using Domain;
using Domain.Repositories;
using PlainCQRS.Core.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Coach.Commands
{
    public class CreateTrainingCommandHandler : ICommandHandlerAsync<CreateTrainingCommand>
    {
        private readonly IWriteRepository<Domain.Coach> repository;

        public CreateTrainingCommandHandler(IWriteRepository<Domain.Coach> repository)
        {
            this.repository = repository;
        }

        public async Task HandleAsync(CreateTrainingCommand command, CancellationToken cancellationToken = default)
        {
            var includes = new string[] { "runners", "Runners", "dbo.Runners" };

            var coach = await repository.GetByAsync(p => p.Id == command.CoachId, includes, cancellationToken);

            var runner = coach.Runners.Find(r => r.Id == command.RunnerId);

            if (runner == null)
                throw new Exception("Coach does not have this runner!");

            var trainingDetails = TraningDetails.Create(command.Details, command.Comments);

            var training = Training.Create(coach, command.TimeToDo, trainingDetails);

            coach.AddTrainigForRunner(runner, training);
        }
    }
}
