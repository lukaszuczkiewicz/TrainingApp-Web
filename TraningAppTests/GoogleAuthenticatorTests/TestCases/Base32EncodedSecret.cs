using NUnit.Framework;
using System.Collections;


namespace TraningAppTests.GoogleAuthenticatorTests.TestCases
{
    public class Base32EncodedSecret     
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData("X5U6MDSR4VDGYSN1");
                yield return new TestCaseData("U732CDXKDESX6O76");
                yield return new TestCaseData("6TYENPKKUS3LEDMR");
                yield return new TestCaseData("IIMIF7WTGEW2YKB2");
                yield return new TestCaseData("3S7UITUFYCXCSF4Y");
                yield return new TestCaseData("A5G6MDSR4VDGYSN6");

            }
        }
    }
}
