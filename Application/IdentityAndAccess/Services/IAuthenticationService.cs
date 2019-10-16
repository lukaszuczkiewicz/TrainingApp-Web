using System.Threading;

namespace Application.IdentityAndAccess.Services
{
    public interface IAuthenticationService<TReqest> where TReqest : LoginRequest
    {
        bool AuthenticateAsync(TReqest request, out string jwtToken, CancellationToken cancellationToken = default);
    }
}
