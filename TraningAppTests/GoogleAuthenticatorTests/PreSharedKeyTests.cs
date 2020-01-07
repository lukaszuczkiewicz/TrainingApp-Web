using NUnit.Framework;
using TraingAppBackEnd.GoogleAuthenticator;

namespace TraningAppTests.GoogleAuthenticatorTests
{
    [TestFixture]
    public class PreSharedKeyTests
    {
        private PreSharedKey PreSharedKeyGenerator;
        private const int properLength = 16;

        [SetUp]
        public void SetUp()
        {
            PreSharedKeyGenerator = new PreSharedKey();
        }


        [Test]
        public void ShoudGenerateProperPreSharedKey()
        {
            var key = PreSharedKeyGenerator.GeneratePresharedKey();

            Assert.IsNotEmpty(key);
            Assert.That(key, Is.InstanceOf<string>());
            Assert.That(key, Has.Length.EqualTo(properLength));
        }
    }
}
