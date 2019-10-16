using Application.IdentityAndAccess.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TraingAppBackEnd.GoogleAuthenticator;

namespace TraingAppBackEnd.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IKeyService keyService;
        private readonly IPreSharedKey preSharedKey;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly IAuthenticationService<LoginRequest> authService;               

        public AuthController(
            IKeyService keyService,
            IPreSharedKey preSharedKey,
            IConfiguration configuration,
            IMapper mapper,
            IAuthenticationService<LoginRequest> authService
            )
        {
            this.keyService = keyService;
            this.preSharedKey = preSharedKey;
            this.configuration = configuration;
            this.mapper = mapper;
            this.authService = authService;
        }

        [HttpPost("login")]
        public IActionResult LogIn([FromBody] LoginRequest loginReqest)
        {
            string token = "";

            var authResult = authService.AuthenticateAsync(loginReqest, out token);

            if (authResult == false)
                return Unauthorized("Bad Credentials");

            return Ok(new { JwtToken = token });
        }  
        
        [Authorize]
        [HttpGet("pre-shared-key")]
        public IActionResult GetPreSharedKey()
        {
            var key = preSharedKey.GeneratePresharedKey();

            return Ok(new { key });
        }
    }
}