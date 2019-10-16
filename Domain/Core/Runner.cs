using Domain.SharedKernel;
using System.Collections.Generic;

namespace Domain
{
    public class Runner : Entity, IUser
    {
        protected Runner() { }

        private Runner(string login, string password, string firstName, string lastName, string preSharedKey, string email)
        {

            Email = Email.Create(email);
            Login = login;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            PreSharedKey= preSharedKey;
        }

        public static Runner Create (string firstName, string password, string lastName, string login, string email, string preSharedCode)
        {
            return new Runner(firstName, password, lastName, login, email, preSharedCode);
        }

        public List<Training> Trainings { get; private set; } =
            new List<Training>();

        public string Login { get; private set; }

        public string Password { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Email Email { get; private set; }
        public Coach Coach { get; private set; }

        public string PreSharedKey { get; private set; }

        public void Update(string firstName, string lastName, string login, Email email)
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Email = email;
        }

        public void AddTrainig(Training training)
        {
            Trainings.Add(training);
            //ApplyEvent(new TrainingAdded(...))
        }
    }
}
