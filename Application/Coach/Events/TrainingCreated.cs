using PlainCQRS.Core.Events;
using System;

namespace Application.Coach.Events
{
    public class TrainingCreated : IEvent
    {
        public TrainingCreated(Guid id, DateTime created, string coachName, string runnerEmailAddress)
        {
            Id = id;
            Created = created;
            CoachName = coachName;
            RunnerEmailAddress = runnerEmailAddress;
        }
        private TrainingCreated()
        {

        }

        public Guid Id { get; private set; }
        public DateTime Created { get; private set; }
        public string CoachName { get; private set; }
        public string TrainingDetail { get; set; }
        public string RunnerEmailAddress { get; set; }

    }
}
