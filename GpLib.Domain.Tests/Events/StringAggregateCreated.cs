using GpLib.Domain.Abstractions;
using System;

namespace GpLib.Domain.Tests
{
    public class StringAggregateCreated : DomainEvent
    {
        private const int VERSION = 0;

        public StringAggregateCreated(int x, string y, string aggregateId, Guid guid) : base(aggregateId, guid, VERSION)
        {
            X = x;
            Y = y;
        }

        public int X { get; protected set; }

        public string Y { get; protected set; }
    }
}
