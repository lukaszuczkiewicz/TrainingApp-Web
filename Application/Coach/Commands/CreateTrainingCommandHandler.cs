using Application.Coach.Events;
using Domain;
using Domain.Repositories;
using PlainCQRS.Core.Commands;
using PlainCQRS.Core.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Coach.Commands
{
    public class CreateTrainingCommandHandler : ICommandHandlerAsync<CreateTrainingCommand>
    {
        private readonly IWriteRepository<Domain.Coach> repository;
        private readonly IEventPublisher eventPublisher;

        public CreateTrainingCommandHandler(IWriteRepository<Domain.Coach> repository, IEventPublisher eventPublisher)
        {
            this.repository = repository;
            this.eventPublisher = eventPublisher;
        }

        public async Task HandleAsync(CreateTrainingCommand command, CancellationToken cancellationToken = default)
        {
            var coach = await repository.GetByAsync(p => p.Id == command.CoachId, new[] { "Runners" }, cancellationToken);

            if(coach.Runners.Capacity == 0)
                throw new ArgumentNullException("Coach does not have this runner!");

            var runner = coach.Runners.Find(r => r.Id == command.RunnerId);

            if (runner == null)
                throw new ArgumentNullException("Coach does not have this runner!");

            var trainingDetails = TraningDetails.Create(command.Details, command.Comments);

            var training = Training.Create(command.TimeToDo, trainingDetails);

            coach.AddTrainigForRunner(runner, training);

            var coachName = $"{coach.FirstName} {coach.LastName}";

            eventPublisher.Publish(new TrainingCreated(training.Id, DateTime.Now, coachName, runner.Email.ToString()));
        }
    }
}
