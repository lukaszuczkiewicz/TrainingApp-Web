using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Team
    {
        IEnumerable<Runner> Runners { get;  }
        IEnumerable<Coach> Coaches { get; }

    }
}
