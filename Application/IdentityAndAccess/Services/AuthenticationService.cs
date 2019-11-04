using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using PlainCQRS.Core.Queries;
using ApplicationQueries.IdentityAndAccess;
using Microsoft.Extensions.Options;
using TraingAppBackEnd.GoogleAuthenticator;

namespace Application.IdentityAndAccess.Services
{
    public class AuthenticationService : IAuthenticationService<LoginRequest>
    {
        private readonly IOptions<JwtOptions> jwtOptions;
        private readonly IPasswordService passwordService;
        private readonly IQueryDispatcherAsync queryDispatcher;
        private readonly IKeyService keyService;

        public AuthenticationService(IOptions<JwtOptions> jwtOptions, 
            IPasswordService passwordService, 
            IQueryDispatcherAsync queryDispatcher,
            IKeyService keyService)
        {
            this.jwtOptions = jwtOptions;
            this.passwordService = passwordService;
            this.queryDispatcher = queryDispatcher;
            this.keyService = keyService;
        }

        public bool AuthenticateAsync(LoginRequest request, out string jwtToken, CancellationToken cancellationToken = default)
        {
            jwtToken = "";
            var user = queryDispatcher.ExecuteAsync(new FindApplicationUserQuery(request.Login));

            if (user == null)
                return false;

            if (!passwordService.IsValid(request.Password, user.Result.Password))
                return false;

            if (!keyService.IsValid(request.Code, user.Result.PreSharedKey))
                return false;

            jwtToken = CreateTokenString(request.Login, user.Result.Id);
            return true;
        }

        private string CreateTokenString(string login, Guid id)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, login));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, id.ToString()));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expTime = DateTime.Now.AddMinutes(jwtOptions.Value.ExpTimeInMinutes);

            var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
                issuer: jwtOptions.Value.Issuer,
                audience: jwtOptions.Value.Audience,
                claims: claims,
                expires: expTime,
                signingCredentials: creds);

            var tokenString = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
