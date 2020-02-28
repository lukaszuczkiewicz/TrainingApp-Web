using PlainCQRS.Core.Queries;
using System;

namespace ApplicationQueries.Runners
{
    public class GetRunnerQuery: IQuery<RunnerViewModel>
    {
        public GetRunnerQuery(Guid runnerId)
        {
            RunnerId = runnerId;
        }

        public Guid RunnerId { get; private set; }
    }
}
