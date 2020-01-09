using Domain.SharedKernel;
using System.Collections.Generic;

namespace Domain
{
    public class Runner : Entity
    {
        protected Runner() { }

        private Runner(string firstName, string lastName, Email email)
        {

            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public static Runner Create (string firstName, string lastName, Email email)
        {
            return new Runner(firstName, lastName, email);
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public virtual Email Email { get; private set; }

        public virtual List<Training> Trainings { get; private set; } =
            new List<Training>();

        public virtual Coach Coach { get; private set; }

        public void Update(string firstName, string lastName, Email email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public void AddTrainig(Training training)
        {
            Trainings.Add(training);
            //ApplyEvent(new TrainingAdded(...))
        }
    }
}
