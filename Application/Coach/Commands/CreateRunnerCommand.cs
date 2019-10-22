using PlainCQRS.Core.Commands;

namespace Application.Coach.Commands
{
    public class CreateRunnerCommand : ICommand
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string Email { get; private set; }
    }
}
