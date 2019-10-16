using PlainCQRS.Core.Commands;
using System;

namespace Application.Coach.Commands
{
    public class CreateTrainingCommand : ICommand
    {
        public CreateTrainingCommand(Guid coachId, Guid runnerId, 
            DateTime timeToDo, string details, string comments)
        {
            CoachId = coachId;
            RunnerId = runnerId;
            TimeToDo = timeToDo;
            Details = details;
            Comments = comments;
        }

        public Guid CoachId { get; private set; }
        public Guid RunnerId { get; private set; }
        public DateTime TimeToDo {get; private set; }
        public string Details { get; private set; }
        public string Comments { get; private set; }     
    }
}
