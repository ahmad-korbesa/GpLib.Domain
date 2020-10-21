using System;

namespace GpLib.Domain.Abstractions
{
    public abstract class DomainEvent<TAggregateKey>
    {
        
        protected DomainEvent(TAggregateKey aggregateId, Guid guid, int version)
        {
            AggregateId = aggregateId;

            Timestamp = DateTime.Now;
            
            Guid = guid;
            
            Version = version;
        }

        public TAggregateKey AggregateId { get; protected set; }

        public DateTime Timestamp { get; protected set; }

        public int Version { get; protected set; }

        public Guid Guid { get; protected set; }
    }
}
