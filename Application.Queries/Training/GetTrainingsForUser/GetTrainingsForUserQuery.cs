using PlainCQRS.Core.Queries;
using System;
using System.Collections.Generic;

namespace Application.Queries.Training.GetTrainingsForUser
{
    public class GetTrainingsForUserQuery : IQuery<IEnumerable<TrainingViewModel>>

    {
        public GetTrainingsForUserQuery(Guid userId)
        {
            UserId = userId;
        }
        public Guid UserId { get; protected set; }
    }
}
