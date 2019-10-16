using System;

namespace ApplicationQueries.IdentityAndAccess
{
    public class ApplicationUserViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Guid Id { get; set; }
        public string PreSharedKey { get; set; }
    }
}
