using PlainCQRS.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationQueries.IdentityAndAccess
{
    public class GetUserByFirsAndSecondNameQuery : IQuery<bool>
    {
        public string FirstName { get; set; }
        public string MyProperty { get; set; }
    }
}
