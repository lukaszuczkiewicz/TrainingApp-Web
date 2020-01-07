using Domain;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Persistence;
using Persistence.EntityFramowork;
using System;
using System.Linq.Expressions;
using System.Threading;
using TraningAppTests.Shared.CoachTestCases;

namespace TraningAppTests.Persistance.EFTests
{
    [TestFixture]
    public class WriteRepositoryTests
    {
        private DbContextOptions<DataBaseContext> options;
        private Coach additionalCoach;
        private Email additionalEmail;
        private const string additionalEmailAddres = "email@email.com";

        [SetUp]
        public void SetUp()
        {
            options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase($"TraningApp {Guid.NewGuid()}")
                .Options;

            additionalEmail = Email.Create(additionalEmailAddres);
            additionalCoach = Coach.Create("abc", "abc", "abc", "abc", additionalEmail);
        }

        [Test]
        [TestCaseSource(typeof(CoachTestCases), "TestCases")]
        public void GetByFirstNameAsyncShouldReturnCoach(string emailAddres, string login, string password, string firstName, string lastName)
        {
            var email = Email.Create(emailAddres);
            var aggregateRoot = Coach.Create(login, password , firstName, lastName, email);
            Expression<Func<Coach, bool>> predictate = (x) => x.FirstName == firstName;

            using (var context = new DataBaseContext(options))
            {
                context.Coaches.Add(aggregateRoot);
                context.Coaches.Add(additionalCoach);

                context.SaveChanges();

                var coachesRepository = new WriteRepository<Coach>(context);

                var coach = coachesRepository
                    .GetByAsync(predictate, new string[] { }, It.IsAny<CancellationToken>())
                    .GetAwaiter()
                    .GetResult();

                Assert.AreSame(coach, aggregateRoot);
                Assert.AreEqual(coach, aggregateRoot);
            }
        }            
    }
}
