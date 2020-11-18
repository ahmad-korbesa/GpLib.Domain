using GpLib.Domain.Abstractions;
using System;

namespace GpLib.Domain.Tests
{
    //public record StringAggregateMissingEvent
    //    (string AggregateId, Guid EventId, DateTime Timestamp) :
    //    DomainEvent<string>(AggregateId, Timestamp, 0, EventId)
    //{ }

    public class StringAggregateMissingEvent : DomainEvent<string>
    {
        public StringAggregateMissingEvent(string aggregateId, Guid eventId, DateTime timestamp) : base(aggregateId, timestamp, 0, eventId)
        {
        }
    }

}
