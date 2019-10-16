using Domain.SharedKernel;

namespace Domain
{
    public interface IUser
    {
        string Login { get; }
        string Password { get; }
        string FirstName { get; }
        string LastName { get; }
        Email Email { get; }
        string PreSharedKey { get; }
    }
}
