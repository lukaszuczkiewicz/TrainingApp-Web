using Domain.Core;
using Domain.SharedKernel;
using System.Collections.Generic;

namespace Domain
{
    public sealed class Coach : Entity, IUser
    {
        private Coach(string login, string password, string firstName, string lastName, Email email)
        { }

        protected Coach() { } // EF Core

        public static Coach Create(string login, string password, string firstName, string lastName, Email email)
        {
            return new Coach(login, password, firstName, lastName, email);
        }

        public List<Runner> Runners { get; private set; } 
            = new List<Runner>();

        public string Login { get; private set; }

        public string Password { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Email Email { get; private set; }

        public string PreSharedKey { get; private set; }

        public void AddRunner(Runner runner)
        {
            Runners.Add(runner);
        }

        public void AddTrainigForRunner(Runner runner, Training training)
        {
            runner.AddTrainig(training);
        }
        public void AddTrainigForClub(Club club, Training training)
        {
            club.AddTraining(training);
        }
    }
}
