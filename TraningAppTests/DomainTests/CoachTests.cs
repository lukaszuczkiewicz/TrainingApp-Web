using Domain;
using NUnit.Framework;
using FluentAssertions;
using TraningAppTests.Shared.CoachTestCases;

namespace TraningAppTests.DomainTests
{
    [TestFixture]
    class CoachTests
    {
        private Email emailMock;
        private const string emailAddresMock = "email@email.com";
             
        [SetUp]
        public void SetUp()
        {
            emailMock = Email.Create(emailAddresMock);
        }

        #region Getters
        [Test]
        [TestCaseSource(typeof(CoachTestCases), "TestCases")]
        public void CreateMethodShoudlReturnProperLoginOfCoach(string emailAddres, string login, string password, string firstName, string lastName, string preSharedKey)
        {
            var coach = Coach.Create(login, password, firstName, lastName, preSharedKey, emailMock);

            coach.Login.Should().NotBeNullOrWhiteSpace();
            coach.Login.Should().BeEquivalentTo(login);
        }

        [Test]
        [TestCaseSource(typeof(CoachTestCases), "TestCases")]
        public void CreateMethodShoudlReturnProperPasswordOfCoach(string emailAddres, string login, string password, string firstName, string lastName, string preSharedKey)
        {
            var coach = Coach.Create(login, password, firstName, lastName, preSharedKey, emailMock);

            coach.Password.Should().NotBeNullOrWhiteSpace();
            coach.Password.Should().BeEquivalentTo(password);
        }

        [Test]
        [TestCaseSource(typeof(CoachTestCases), "TestCases")]
        public void CreateMethodShoudlReturnProperFirstNameOfCoach(string emailAddres, string login, string password, string firstName, string lastName, string preSharedKey)
        {
            var coach = Coach.Create(login, password, firstName, lastName, preSharedKey, emailMock);

            coach.FirstName.Should().NotBeNullOrWhiteSpace();
            coach.FirstName.Should().BeEquivalentTo(firstName);
        }

        [Test]
        [TestCaseSource(typeof(CoachTestCases), "TestCases")]
        public void CreateMethodShoudlReturnProperLastNameOfCoach(string emailAddres, string login, string password, string firstName, string lastName, string preSharedKey)
        {
            var coach = Coach.Create(login, password, firstName, lastName, preSharedKey, emailMock);

            coach.FirstName.Should().NotBeNullOrWhiteSpace();
            coach.FirstName.Should().BeEquivalentTo(firstName);
        }

        #endregion
    }
}
