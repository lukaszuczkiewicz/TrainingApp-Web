namespace Persistence.Abstractions
{
    public interface IDbConfigProvider
    {
        ConnectionStrings ConnectionStrings { get; }
    }
}
