using PlainCQRS.Core.Commands;
using System;

namespace Application.Coach.Commands
{
    public class UpdateTrainingCommand : ICommand
    {
        public UpdateTrainingCommand(Guid id, Guid runnerId, 
            DateTime timeToDo, string details, string comments)
        {
            Id = id;
            RunnerId = runnerId;
            TimeToDo = timeToDo;
            Details = details;
            Comments = comments;
        }

        public Guid Id { get; private set; }
        public Guid RunnerId { get; private set; }
        public DateTime TimeToDo {get; private set; }
        public string Details { get; private set; }
        public string Comments { get; private set; }     
    }
}
