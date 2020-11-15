using System;

namespace GpLib.Domain.Abstractions
{
    public abstract record DomainEvent<TAggregateKey>
        (TAggregateKey AggregateId, DateTime Timestamp, int Version, Guid EventId)
    {
    }
}
