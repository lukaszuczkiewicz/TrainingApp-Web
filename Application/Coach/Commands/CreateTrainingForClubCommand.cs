using PlainCQRS.Core.Commands;
using System;

namespace Application.Coach.Commands
{
    public class CreateTrainingForRunnerCommand : ICommand
    {
        public Guid CoachId { get; private set; }
        public Guid RunnerId { get; private set; }
        public DateTime DateToDo { get; private set; }
        public int MyProerty { get; private set; }
        public string Details { get; private set; }
        public string Comment { get; private set; }
    }
}
