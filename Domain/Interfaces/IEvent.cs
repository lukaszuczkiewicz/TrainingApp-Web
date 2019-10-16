using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IEvent
    {
        Guid Id { get; }
        Guid EntityId { get; }
        DateTime EventDate { get; }
    }
}
