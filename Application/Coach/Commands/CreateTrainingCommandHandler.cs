using Application.Coach.Events;
using Domain;
using Domain.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using PlainCQRS.Core.Commands;
using PlainCQRS.Core.Events;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Coach.Commands
{
    public class CreateTrainingCommandHandler : ICommandHandlerAsync<CreateTrainingCommand>
    {
        private readonly IWriteRepository<Domain.Coach> repository;
        private readonly IEventPublisherAsync eventPublisher;
        private readonly IHttpContextAccessor httpContext;

        public CreateTrainingCommandHandler(
            IWriteRepository<Domain.Coach> repository, 
            IEventPublisherAsync eventPublisher,
            IHttpContextAccessor httpContext)
        {
            this.repository = repository;
            this.eventPublisher = eventPublisher;
            this.httpContext = httpContext;
        }

        public async Task HandleAsync(CreateTrainingCommand command, CancellationToken cancellationToken = default)
        {
            Guid.TryParse(httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, 
                out Guid coachId);

            var coach = await repository.GetByAsync(p => p.Id == coachId, new[] { "Runners" }, cancellationToken);
            if (coach.Runners.Capacity == 0)
                throw new ArgumentNullException("Coach does not have this runner!");

            var runner = coach.Runners.Find(r => r.Id == command.RunnerId);

            if (runner == null)
                throw new ArgumentNullException("Coach does not have this runner!");

            var trainingDetails = TraningDetails.Create(command.Details, command.Comments);

            var training = Training.Create(command.TimeToDo, trainingDetails);

            coach.AddTrainigForRunner(runner, training);

            var coachName = $"{coach.FirstName} {coach.LastName}";

            await eventPublisher.PublishAsync<TrainingCreated>
                (new TrainingCreated(training.Id, DateTime.Now, coachName, runner.Email.EmailAdress));
        }
    }
}
