using PlainCQRS.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;

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
