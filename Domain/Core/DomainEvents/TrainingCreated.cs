using PlainCQRS.Core.Events;
using System;

namespace Domain.Core.DomainEvents
{
    public class TrainingCreated : IEvent
    {
        public Guid Id { get; private set; }
        public DateTime Created { get; private set; }
        public string CoachName { get; private set; }

    }
}
