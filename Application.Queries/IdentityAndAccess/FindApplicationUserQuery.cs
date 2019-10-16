using PlainCQRS.Core.Queries;

namespace ApplicationQueries.IdentityAndAccess
{
    public class FindApplicationUserQuery : IQuery<ApplicationUserViewModel>
    {
        public FindApplicationUserQuery(string login)
        {
            Login = login;
        }

        public string Login { get; private set; }
    }
}