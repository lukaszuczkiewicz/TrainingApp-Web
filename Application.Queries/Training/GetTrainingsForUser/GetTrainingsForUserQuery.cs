using PlainCQRS.Core.Queries;
using System;
using System.Collections.Generic;

namespace Application.Queries.Training.GetTrainingsForUser
{
    public class GetRunnerTrainingsInMonth : IQuery<IEnumerable<TrainingViewModel>>

    {
        public GetRunnerTrainingsInMonth(Guid runnerId)
        {
            RunnerId = runnerId;
        }

        public Guid RunnerId { get; protected set; }
    }
}
