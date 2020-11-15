using GpLib.Domain.Abstractions;
using System;

namespace GpLib.Domain.Tests
{
    public record ValueAdded2
        (double Value, Guid AggregateId, Guid EventId, DateTime Timestanp)
        : DomainEvent<Guid>(AggregateId, Timestanp, 0, EventId)
    {
    }
}
