using NUnit.Framework;
using TraingAppBackEnd.GoogleAuthenticator;
using TraningAppTests.GoogleAuthenticatorTests.TestCases;

namespace TraningAppTests.GoogleAuthenticatorTests
{
    [TestFixture]
    public class TimeSensetivePassCodeTests
    {
        private TimeSensetivePassCode timesensetivePassCode;
        private const int properLength = 6;

        [SetUp]
        public void SetUp()
        {
            timesensetivePassCode = new TimeSensetivePassCode();
        }

        [Test]
        [TestCaseSource(typeof(Base32EncodedSecret), "TestCases")]
        public void ToptShoudReturnProperValue(string base32EncodedSecret)
        {
            var topt = timesensetivePassCode.GetTopt(base32EncodedSecret);

            Assert.That(topt, Is.InstanceOf<string>());
            Assert.IsNotEmpty(topt);
            Assert.That(topt, Has.Length.EqualTo(properLength));
        }

        [Test]
        [TestCaseSource(typeof(Base32EncodedSecret), "TestCases")]
        public void ToptShoudBeANumber(string base32EncodedSecret)
        {
            var topt = timesensetivePassCode.GetTopt(base32EncodedSecret);

            Assert.DoesNotThrow(() => { int.Parse(topt); });
        }
    }
}
