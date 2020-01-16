using ApplicationQueries.SharedViewModels;
using PlainCQRS.Core.Queries;
using System.Collections.Generic;

namespace ApplicationQueries.Runners
{
    public class GetCoachesQuery : IQuery<List<CoachWithEmailViewModel>>
    { }
}
