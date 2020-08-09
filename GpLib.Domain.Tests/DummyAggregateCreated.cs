using GpLib.Domain.Abstractions;
using System;

namespace GpLib.Domain.Tests
{
    public class DummyAggregateCreated : DomainEvent<int>
    {
        private const int VERSION = 0;

        public DummyAggregateCreated(int x, string y, int aggregateId, Guid guid) : base(aggregateId, guid, VERSION)
        {
            X = x;
            Y = y;
        }

        public int X { get; protected set; }
        public string Y { get; protected set; }
    }
}
