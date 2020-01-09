using Application.Coach.Commands;
using Domain.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Persistence;
using Persistence.EntityFramowork;
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

            await coachCommandHandler.HandleAsync(command);

            var coach = context.Coaches
                .Where(x => x.Login == login)
                .Include(x => x.Email)
                .FirstOrDefault();

            Assert.IsTrue(validationResult.IsValid);
            Assert.AreEqual(coach.Login, login);
            Assert.AreEqual(coach.Password, password);
            Assert.AreEqual(coach.FirstName, firstName);
            Assert.AreEqual(coach.LastName, lastName);
            Assert.AreEqual(coach.PreSharedKey, preSharedKey); 
            Assert.That(coach.Id, Is.Not.Null);         
        }          
    }
}
