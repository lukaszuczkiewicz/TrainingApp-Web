using Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class TraningDetails : Entity
    {
        public string Details { get; protected set; }
        public string Comment { get; protected set; }

        private TraningDetails(string details, string comment)
        {
            Details = details;
            Comment = comment;
        }

        protected TraningDetails() { }

        public static TraningDetails Create(string details, string comment) => new TraningDetails(details, comment);

    }
}
