using Domain;
using PlainCQRS.Core.Commands;
using System;

namespace Application.Coach.Commands
{
    public class UpdateRunnerCommand: ICommand
    {
        public UpdateRunnerCommand(Guid id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = Email.Create(email);
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Email Email { get; set; }
    }
}