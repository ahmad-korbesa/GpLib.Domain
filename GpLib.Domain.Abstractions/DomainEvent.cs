using System;

namespace GpLib.Domain.Abstractions
{
    public abstract class DomainEvent<TAggregateKey>
    {
        
        protected DomainEvent(TAggregateKey aggregateId, Guid guid, int version)
        {
            AggregateId = aggregateId;
            Guid = guid;
            Version = version;
        }

        public TAggregateKey AggregateId { get; protected set; }

        public int Version { get; protected set; }

        public Guid Guid { get; protected set; }
    }
}
