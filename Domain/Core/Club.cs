using Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core
{
    public class Club : Entity
    {
        private Club (Coach coach, string name)
            : base() 
        {
            Coach = coach;
            Name = name;
        }

        protected Club () { }

        public static Club Create(Coach coach, string name) => new Club(coach, name);
        public void AddRunner(Runner runner)
        {
            Runners.Add(runner);
        }

        public Coach Coach { get; private set; }
        public ICollection<Runner> Runners { get; private set; } = new List<Runner>();
        public string Name { get; set; }

        public void AddTraining(Training training)
        {
            foreach(var runner in Runners)
            {
                runner.Trainings.Add(training);
            }
        }
    }
}
