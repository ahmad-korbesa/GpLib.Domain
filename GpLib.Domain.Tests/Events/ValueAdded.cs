using GpLib.Domain.Abstractions;
using System;

namespace GpLib.Domain.Tests
{
    //public record ValueAdded
    //    (double Value, string AggregateId, Guid EventId, DateTime Timestamp) :
    //    DomainEvent<string>(AggregateId, Timestamp, 0, EventId)
    //{ }

    public class ValueAdded : DomainEvent<string>
    {
        public ValueAdded(double value, string aggregateId, Guid eventId, DateTime timestamp) : base(aggregateId, timestamp, 0, eventId)
        {
            Value = value;
        }

        public double Value { get; }
    }

}
