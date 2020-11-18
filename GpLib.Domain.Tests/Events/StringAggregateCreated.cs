using GpLib.Domain.Abstractions;
using System;

namespace GpLib.Domain.Tests
{
    //public record StringAggregateCreated
    //    (int X, string Y, string AggregateId, Guid EventId, DateTime Timestamp) :
    //    DomainEvent<string>(AggregateId, Timestamp, 0, EventId)
    //{ }

    public class StringAggregateCreated : DomainEvent<string>
    {
        public StringAggregateCreated(int x, string y, string aggregateId, Guid eventId, DateTime timestamp) : base(aggregateId, timestamp, 0, eventId)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public string Y { get; }
    }

}
