using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SharedKernel
{
    public class AggregateRoot : Entity
    {
        ICollection<IEvent> Events;
    }
}
