using GpLib.Domain.Abstractions;
using System;

namespace GpLib.Domain.Tests
{
    public record GuidAggregateCreated
        (int X, string Y, Guid AggregateId, Guid EventId, DateTime Timestamp) :
        DomainEvent<Guid>(AggregateId, Timestamp, 0, EventId)
    { }
}
