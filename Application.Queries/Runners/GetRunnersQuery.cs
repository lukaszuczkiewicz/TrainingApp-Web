using PlainCQRS.Core.Queries;
using System.Collections.Generic;

namespace ApplicationQueries.Runners
{
    public class GetRunnersQuery : IQuery<IEnumerable<RunnerViewModel>>
    {
        public GetRunnersQuery()
        { }
    }
}
