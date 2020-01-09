using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SharedKernel
{
    public abstract class AggregateRoot
    {
        protected AggregateRoot()
        {
            Id = Guid.NewGuid();
        }

        public virtual Guid Id { get; protected set; }
        protected virtual object Actual => this;
    }
}
