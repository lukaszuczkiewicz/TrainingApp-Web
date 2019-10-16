using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IdentityAndAccess.Services
{
    public interface IPasswordService
    {
        bool IsValid(string actualPassword, string hashedPassword);
    }
}
