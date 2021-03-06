﻿using GpLib.Domain.Abstractions;
using System;

namespace GpLib.Domain.Tests
{
    //public record ValueAdded2
    //    (double Value, Guid AggregateId, Guid EventId, DateTime Timestanp)
    //    : DomainEvent<Guid>(AggregateId, Timestanp, 0, EventId)
    //{
    //}

    public class ValueAdded2 : DomainEvent<Guid>
    {
        public ValueAdded2(double value, Guid aggregateId, Guid eventId, DateTime timestamp) : base(aggregateId, timestamp, 0, eventId)
        {
            Value = value;
        }

        public double Value { get; }
    }

}
