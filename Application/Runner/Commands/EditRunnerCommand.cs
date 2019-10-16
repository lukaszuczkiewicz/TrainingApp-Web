using PlainCQRS.Core.Commands;
using System;

namespace Application.Runner.Commands
{
    public sealed class UpdateRunnerCommand : ICommand
    {
        public UpdateRunnerCommand(Guid id, string login, string firstName, string lastName, string email)
        {
            Id = id;
            Login = login ?? throw new ArgumentNullException(nameof(login));
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        public Guid Id { get; private set; }
        public string Login { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
    }
}
