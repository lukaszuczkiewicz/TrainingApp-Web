using Application.Queries.Training.GetTrainingsForUser;
using PlainCQRS.Core.Queries;
using System.Collections.Generic;

namespace ApplicationQueries.Training
{
    public class GetTrainingsQuery: IQuery<IEnumerable<TrainingToReturnViewModel>>
    {
        public GetTrainingsQuery()
        { }
    }
}
