using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Team
    {
        public virtual IEnumerable<Runner> Runners { get; }
        public virtual IEnumerable<Coach> Coaches { get; }

    }
}
