using Domain;
using System;

namespace Api.ViewModels
{
    public class UpdateRunnerViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid Id { get; set; }
    }
}