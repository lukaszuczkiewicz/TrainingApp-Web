using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationQueries.Runners
{
    public class RunnerViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
