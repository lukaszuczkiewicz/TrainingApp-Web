using Application.Coach.Commands;
using Domain.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Persistence;
using Persistence.EntityFramowork;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TraningAppTests.Shared;
using TraningAppTests.Shared.CoachTestCases;

namespace TraningAppTests.Application.Coach.Commands
{

    public class CreateRunnerCommandTests
    {
        private DataBaseContext context;
        private WriteRepository<Domain.Coach> repository;
        private CreateRunnerCommandHandler createRunnerCommandHandler;
        private CreateRunnerCommandValidator validator;
        private Mock<IHttpContextAccessor> httpContextMock;
        private DefaultHttpContext httpContext;

        [SetUp]
        public void StartUp()
        {
            httpContextMock = new Mock<IHttpContextAccessor>();
            httpContext = new DefaultHttpContext();

            context = DbContextFactory.CreateWithData();
            repository = new WriteRepository<Domain.Coach>(context);           
            createRunnerCommandHandler = new CreateRunnerCommandHandler(repository, httpContextMock.Object);
            validator = new CreateRunnerCommandValidator();  
        }

        [Test]
        [TestCase("RunnerFirstName", "RunnerLastName", "runner@gmail.com")]
        public async Task CoachShouldCreateProperRunner(string firstName, string lastName, string emailAddress)
        {
            var coachId = context.Coaches.FirstOrDefault().Id.ToString();

            httpContextMock.Setup(x => x.HttpContext
                                        .User
                                        .FindFirst(It.IsAny<string>()))
                           .Returns(new Claim(ClaimTypes.NameIdentifier, coachId));

            var command = new CreateRunnerCommand(firstName, lastName, emailAddress);

            var commandHandler = new CreateRunnerCommandHandler(repository, httpContextMock.Object);

            var runners2 = context.Runners.ToList();

            await commandHandler.HandleAsync(command);

            var runners = context.Runners.ToList();
        }
    }
}
