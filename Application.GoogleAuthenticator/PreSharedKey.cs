using System.Security.Cryptography;

namespace TraingAppBackEnd.GoogleAuthenticator
{
    public class PreSharedKey : IPreSharedKey
    {
        public string GeneratePresharedKey()
        {
            var key = new byte[10];
            using (var rngProvider = new RNGCryptoServiceProvider())
            {
                rngProvider.GetBytes(key);
            }

            var result = StringHelper.ToBase32String(key);

            return result;
        }
    }
}
