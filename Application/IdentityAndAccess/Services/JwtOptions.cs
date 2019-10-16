using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IdentityAndAccess.Services
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecurityKey { get; set; }
        public int ExpTimeInMinutes { get; set; }
    }
}
