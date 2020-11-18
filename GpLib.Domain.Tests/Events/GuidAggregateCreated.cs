using GpLib.Domain.Abstractions;
using System;

namespace GpLib.Domain.Tests
{
    //public record GuidAggregateCreated
    //    (int X, string Y, Guid AggregateId, Guid EventId, DateTime Timestamp) :
    //    DomainEvent<Guid>(AggregateId, Timestamp, 0, EventId)
    //{ }

    public class GuidAggregateCreated : DomainEvent<Guid>
    {
        public GuidAggregateCreated(int x, string y, Guid aggregateId, Guid eventId, DateTime timestamp) : base(aggregateId, timestamp, 0, eventId)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public string Y { get; }
    }

}
