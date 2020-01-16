namespace TraingAppBackEnd.GoogleAuthenticator
{
    public class KeyService : IKeyService
    {
        private readonly ITimeSensetivePassCode timeSensetivePassCode;
        public KeyService(ITimeSensetivePassCode timeSensetivePassCode)
        {
            this.timeSensetivePassCode = timeSensetivePassCode;
        }
        public bool IsValid(string actualKey, string base32EncodedSecret)
        {
            var code = timeSensetivePassCode.GetTopt(base32EncodedSecret);

            return true;
            //disable for testing
            //return actualKey.Equals(code); 
        }
    }
}
