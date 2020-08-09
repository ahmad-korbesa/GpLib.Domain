using GpLib.Domain.Abstractions;
using System;

namespace GpLib.Domain.Tests
{
    public class GuidAggregateCreated : DomainEvent
    {
        private const int VERSION = 0;

        public GuidAggregateCreated(int x, string y, Guid aggregateId, Guid guid) : base(aggregateId, guid, VERSION)
        {
            X = x;
            Y = y;
        }

        public int X { get; protected set; }

        public string Y { get; protected set; }
    }
}
