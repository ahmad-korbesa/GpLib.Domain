using System;

namespace GpLib.Domain.Abstractions
{
    //public abstract record DomainEvent<TAggregateKey>
    //    (TAggregateKey AggregateId, DateTime Timestamp, int Version, Guid EventId)
    //{
    //}

    public abstract class DomainEvent<TAggregateKey>
    {
        protected DomainEvent(TAggregateKey aggregateId, DateTime timestamp, int version, Guid eventId)
        {
            AggregateId = aggregateId;
            Timestamp = timestamp;
            Version = version;
            EventId = eventId;
        }

        public TAggregateKey AggregateId { get; }
        public DateTime Timestamp { get; }
        public int Version { get; }
        public Guid EventId { get; }
    }


}
