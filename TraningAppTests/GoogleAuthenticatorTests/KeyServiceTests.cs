using Moq;
using NUnit.Framework;
using TraingAppBackEnd.GoogleAuthenticator;

namespace TraningAppTests.GoogleAuthenticatorTests
{
    [Category("Main GoogleAuthenticatorUsage")]
    [TestFixture]
    public class KeyServiceTests
    {
        private KeyService keyService;
        private Mock<ITimeSensetivePassCode> timeSensetivePassCodeMock;

        [SetUp]
        public void SetUp()
        {
            timeSensetivePassCodeMock = new Mock<ITimeSensetivePassCode>();
            keyService = new KeyService(timeSensetivePassCodeMock.Object);
        }

        [Test]
        [TestCase("X5U6MDSR4VDGYSN1", "940503", "940503")]
        [TestCase("X5U6MDSR4VDGYSN2", "940502", "940502")]
        [TestCase("X5U6MDSR4VDGYSN3", "000000", "000000")]
        public void KeyShoudBeValid(string base32EncodedSecret, string topt, string actualKey)
        {
            timeSensetivePassCodeMock.Setup(x => x.GetTopt(base32EncodedSecret))
                .Returns(topt);

            Assert.That(keyService.IsValid(actualKey, base32EncodedSecret), Is.True);
        }

        [Test]
        [TestCase("X5U6MDSR4VDGYSN1", "000000", "940503")]
        [TestCase("X5U6MDSR4VDGYSN2", "000000", "940502")]
        [TestCase("X5U6MDSR4VDGYSN3", "000000", "940502")]
        public void KeyShoudNotBeValid(string base32EncodedSecret, string topt, string actualKey)
        {
            timeSensetivePassCodeMock.Setup(x => x.GetTopt(base32EncodedSecret))
                .Returns(topt);

            var code = timeSensetivePassCodeMock.Object.GetTopt(base32EncodedSecret);

            Assert.That(keyService.IsValid(actualKey, code), Is.False);
        }

    }
}
