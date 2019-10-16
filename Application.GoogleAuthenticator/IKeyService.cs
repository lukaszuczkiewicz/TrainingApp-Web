namespace TraingAppBackEnd.GoogleAuthenticator
{
    public interface IKeyService
    {
        bool IsValid(string actualKey, string existingKey);
    }
}
