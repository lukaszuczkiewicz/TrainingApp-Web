using Application.Queries.SharedViewModels;
using Domain;
using System;

namespace Application.Queries.Training.GetTrainingsForUser
{
    public class TrainingToReturnViewModel
    {
        //public CoachViewModel Coach { get; protected set; }
        public Guid Id { get; protected set; }
        public DateTime DateToDo { get; protected set; }
        public DateTime Created { get; protected set; }
        public string Details { get; protected set; }
        public string Comment { get; protected set; }
        public bool IsDone { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
    }
}
