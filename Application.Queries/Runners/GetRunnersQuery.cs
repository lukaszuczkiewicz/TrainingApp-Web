using ApplicationQueries.Runners;
using PlainCQRS.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationQueries.Runners
{
    public class GetRunnersQuery : IQuery<IEnumerable<RunnerViewModel>>
    {
        public GetRunnersQuery()
        { }
    }
}
