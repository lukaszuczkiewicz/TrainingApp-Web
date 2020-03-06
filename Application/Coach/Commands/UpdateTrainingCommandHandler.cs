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
    public class UpdateTrainingCommandHandler : ICommandHandlerAsync<UpdateTrainingCommand>
    {
        private readonly IWriteRepository<Domain.Coach> repository;
        private readonly IEventPublisherAsync eventPublisher;
        private readonly IHttpContextAccessor httpContext;

        public UpdateTrainingCommandHandler(
            IWriteRepository<Domain.Coach> repository, 
            IEventPublisherAsync eventPublisher,
            IHttpContextAccessor httpContext)
        {
            this.repository = repository;
            this.eventPublisher = eventPublisher;
            this.httpContext = httpContext;
        }

        public async Task HandleAsync(UpdateTrainingCommand command, CancellationToken cancellationToken = default)
        {
            Guid.TryParse(httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, 
                out Guid coachId);

            var coach = await repository.GetByAsync(p => p.Id == coachId, new[] { "Runners" }, cancellationToken);

            if (coach.Equals(null))
                throw new ArgumentNullException($"There is no coach with Id {coachId}");

            var runnerFromDB = coach.Runners.Find(r => r.Id == command.RunnerId);

            if (runnerFromDB == null)
                throw new ArgumentNullException($"Coach {coachId} does not have this runner {command.RunnerId}!");

            var trainingFromDB = runnerFromDB.Trainings.Find(t => t.Id == command.Id);

            if (trainingFromDB == null)
                throw new ArgumentNullException("Runner does not have this training!");

            var trainingDetails = TraningDetails.Create(command.Details, command.Comments);

            trainingFromDB.Update(command.TimeToDo, trainingDetails);

            await repository.SaveAsync(coach);
        }
    }
}
