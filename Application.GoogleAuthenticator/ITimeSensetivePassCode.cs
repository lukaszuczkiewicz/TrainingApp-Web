namespace TraingAppBackEnd.GoogleAuthenticator
{
    public interface ITimeSensetivePassCode
    {
        string GetTopt(string base32EncodedSecret);
    }
}
