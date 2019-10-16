using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IdentityAndAccess.Services
{
    public class PasswordService : IPasswordService
    {
        public bool IsValid(string actualPassword, string passwordFromDatabase)
        {
            if (actualPassword != passwordFromDatabase)
                return false;

            return true;
        }
    }
}
