using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace TraningAppTests.Shared
{
    public class DbContextFactory
    {
        public static DataBaseContext CreateWithData()
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new DataBaseContext(options);

            context.Database.EnsureCreated();

            var coachEmail = Email.Create("DbContextFactorycoach@email.com");
            var coach = Coach.Create("DbContextFactorylogin", "DbContextFactorypassword", "DbContextFactoryfirstName", "DbContextFactorylastName", "Qwertyqwerty", coachEmail); 

            var runnerEmail = Email.Create("DbContextFactoryrunner@email.com");
            var runner = Runner.Create("DbContextFactoryrunnerName", "DbContextFactoryrunnerLastName", runnerEmail);


            var trainingDetails = TraningDetails.Create("details", "comment");
            var training = Training.Create(DateTime.UtcNow, trainingDetails);

            coach.AddRunner(runner);

            coach.AddTrainigForRunner(runner, training);

            context.Add(coach);
            context.Runners.Add(runner);
            context.Traings.Add(training);

            context.SaveChanges();

            return context;
        }

        public static DataBaseContext DataBaseContext()
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new DataBaseContext(options);

            context.Database.EnsureCreated();

            return context;
        }
    }
}
