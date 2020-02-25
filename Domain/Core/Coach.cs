using Domain.Core;
using Domain.SharedKernel;
using System.Collections.Generic;

namespace Domain
{
    public class Coach : AggregateRoot, IUser
    {
        private Coach(string login, string password, string firstName, string lastName, string preSharedKey, Email email)
        {
            Login = login;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PreSharedKey = preSharedKey;
        }

        protected Coach() { } // EF Core

        public static Coach Create(string login, string password, string firstName, string lastName, string preSharedKey, Email email)
        {
            return new Coach(login, password, firstName, lastName, preSharedKey, email);
        }

        public virtual List<Runner> Runners { get; set; }
            = new List<Runner>();

        public string Login { get; private set; }

        public string Password { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public virtual Email Email { get; private set; }

        public string PreSharedKey { get; private set; }

        public void AddRunner(Runner runner)
        {
            Runners.Add(runner);
        }
        public void UpdateRunner(Runner runner, string id)
        {
            //Runners.Add(runner);
            //var runnerToUpdate = Runners.Find(r => r. = id);
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
