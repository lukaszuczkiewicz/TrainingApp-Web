using System.Collections.Generic;
using Domain.SharedKernel;

namespace Domain
{
    public class Email : Entity
    {
        public string EmailAdress { get; private set; }

        private Email(string emailAdress)
        {
            EmailAdress = emailAdress;
        }

        public static Email Create(string emailAdress)
        {
            return new Email(emailAdress);
        }

    }
}
