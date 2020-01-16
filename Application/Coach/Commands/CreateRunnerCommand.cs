using PlainCQRS.Core.Commands;

namespace Application.Coach.Commands
{
    public class CreateRunnerCommand : ICommand
    {
        public CreateRunnerCommand(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string Email { get; private set; }
    }
}
