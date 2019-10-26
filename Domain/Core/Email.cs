using System;
using System.Collections.Generic;
using Domain.SharedKernel;

namespace Domain
{
    public class Email : ValueObject
    {
        public string EmailAdress { get; private set; }

        private Email(string emailAdress)
        {
            EmailAdress = emailAdress;
        }

        private Email() { }

        public static Email Create(string emailAdress)
        {
            return new Email(emailAdress);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return EmailAdress;
        }
    }
}
