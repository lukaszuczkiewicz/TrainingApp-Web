using Application.Queries.SharedViewModels;
using System;

namespace Application.Queries.Training.GetTrainingsForUser
{
    public class TrainingViewModel
    {
        public CoachViewModel Coach { get; protected set; }

        public DateTime DateToDo { get; protected set; }
        public DateTime Created { get; protected set; }
        //public TraningDetails TraningDetails { get; protected set; }
        // public Runner Runner { get; protected set; }
        public bool IsDone { get; protected set; }
    }
}
