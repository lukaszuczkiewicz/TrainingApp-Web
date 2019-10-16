using System;
using System.Linq;
using System.Security.Cryptography;

namespace TraingAppBackEnd.GoogleAuthenticator
{
    public class TimeSensetivePassCode : ITimeSensetivePassCode
    {
        public string GetTopt(string base32EncodedSecret)
        {
            DateTime epochStart = new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc);

            long counter = (long)Math.Floor((DateTime.UtcNow - epochStart).TotalSeconds / 30);
            return GetHotp(base32EncodedSecret, counter);
        }
        private string GetHotp(string base32EncodedSecret, long counter)
        {
            byte[] message = BitConverter.GetBytes(counter).Reverse().ToArray();
            byte[] secret = base32EncodedSecret.ToByteArray();

            HMACSHA1 hmac = new HMACSHA1(secret, true);

            byte[] hash = hmac.ComputeHash(message);
            int offset = hash[hash.Length - 1] & 0xf;
            int truncatedHash = ((hash[offset] & 0x7f) << 24) |
            ((hash[offset + 1] & 0xff) << 16) |
            ((hash[offset + 2] & 0xff) << 8) |
            (hash[offset + 3] & 0xff);

            int hotp = truncatedHash % 1000000;
            return hotp.ToString().PadLeft(6, '0');
        }
    }
}
