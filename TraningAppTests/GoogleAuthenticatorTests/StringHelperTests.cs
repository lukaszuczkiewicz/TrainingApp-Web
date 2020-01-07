using NUnit.Framework;
using TraingAppBackEnd.GoogleAuthenticator;
using TraningAppTests.GoogleAuthenticatorTests.TestCases;

namespace TraningAppTests.GoogleAuthenticatorTests
{
    [TestFixture]
    public class StringHelperTests
    {
        private const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

        [Test]
        [TestCaseSource(typeof(Base32EncodedSecret), "TestCases")]
        public void ShouldReturnProperByteArray(string testCase)
        {
            var result = testCase.ToByteArray();

            Assert.That(result, Is.TypeOf<byte[]>());
        }

        [Test]
        [TestCaseSource(typeof(Base32EncodedSecret), "TestCases")]
        public void ShouldReturnProperBase32String(string testCase)
        {
            var byteArray = testCase.ToByteArray();
            var result = StringHelper.ToBase32String(byteArray);

            Assert.That(result, Is.TypeOf<string>());
    
            foreach (var letter in result)
            {
                Assert.That(alphabet.Contains(letter), Is.True);
            }
        }
    }
}
