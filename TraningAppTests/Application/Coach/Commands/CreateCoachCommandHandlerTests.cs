using Application.Coach.Commands;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Persistence;
using Persistence.EntityFramowork;
using System;
using System.Linq;
using System.Threading.Tasks;
using TraningAppTests.Shared;
using TraningAppTests.Shared.CoachTestCases;

namespace TraningAppTests.Application.Coach.Commands
{
    [TestFixture]
    public class CreateCoachCommandHandlerTests
    {
        private DataBaseContext context;
        private WriteRepository<Domain.Coach> repository;
        private CreateCoachCommandHandler coachCommandHandler;
        private CreateCoachCommandValidator validator;

        [SetUp]
        public void StartUp()
        {
            context = DbContextFactory.CreateWithData();
            repository = new WriteRepository<Domain.Coach>(context);
            coachCommandHandler = new CreateCoachCommandHandler(repository);
            validator = new CreateCoachCommandValidator();
        }

        [Test]
        [TestCaseSource(typeof(CoachTestCases), "TestCases")]
        [TestCase("custom@gmail.com", "customlogin", "custompassword", "customfirstName", "customlastName", "qwertyqwerty")]
        public async Task ShuldCreateProperCoach(string emailAddres, string login, string password, string firstName, string lastName, string preSharedKey)
        {
            var command = new CreateCoachCommand(login, password, firstName, lastName, emailAddres, preSharedKey);

            var validationResult = validator.Validate(command);

            if (!validationResult.IsValid)
                throw new Exception(validationResult.Errors.ToString());

            await coachCommandHandler.HandleAsync(command);

            var coaches = await context.Coaches.ToListAsync();

            var coach = await context.Coaches
                .Where(x => x.Login == login)
                .Include(x => x.Email)
                .FirstOrDefaultAsync();

            Assert.IsTrue(validationResult.IsValid);
            Assert.AreEqual(coach.Login, login);
            Assert.AreEqual(coach.Password, password);
            Assert.AreEqual(coach.FirstName, firstName);
            Assert.AreEqual(coach.LastName, lastName);
            Assert.AreEqual(coach.PreSharedKey, preSharedKey); 
            Assert.That(coach.Id, Is.Not.Null);         
        }  
        
        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
