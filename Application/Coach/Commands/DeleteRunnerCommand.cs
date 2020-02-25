using PlainCQRS.Core.Commands;
using System;

namespace Application.Coach.Commands
{
    public class DeleteRunnerCommand: ICommand
    {
        public DeleteRunnerCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
