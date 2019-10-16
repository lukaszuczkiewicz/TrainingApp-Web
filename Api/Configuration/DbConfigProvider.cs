using Microsoft.Extensions.Options;
using Persistence.Abstractions;

namespace TraingAppBackEnd.Configuration
{
    public class DbConfigProvider : IDbConfigProvider
    {
        private readonly IOptions<ConnectionStrings> connectionStrings;

        public DbConfigProvider(IOptions<ConnectionStrings> connectionStrings)
        {
            this.connectionStrings = connectionStrings;
        }

        public ConnectionStrings ConnectionStrings { get => connectionStrings.Value;  }
    }
}
