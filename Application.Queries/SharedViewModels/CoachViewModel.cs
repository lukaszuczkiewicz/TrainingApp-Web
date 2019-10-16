using System;

namespace Application.Queries.SharedViewModels
{
    public class CoachViewModel
    {
        public CoachViewModel(Guid id, string displayName)
        {
            Id = id;
            DisplayName = displayName;
        }

        public Guid Id { get; private set; }
        public string DisplayName { get; private set; }
    }
}
