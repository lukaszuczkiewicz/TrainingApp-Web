using System.Collections.Generic;
using Domain.SharedKernel;
using System.Net.Mail;
using System;

namespace Domain
{
    public class Email : ValueObject
    {
        public string EmailAdress { get; private set; }

        private Email(string emailAdress)
        {
            EmailAdress = emailAdress;
        }
        protected Email() { }

        public static Email Create(string emailAdress)
        {
            if (!emailAdress.Contains('@'))
                throw new ArgumentException();

            return new Email(emailAdress);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return EmailAdress;
        }
    }
}
