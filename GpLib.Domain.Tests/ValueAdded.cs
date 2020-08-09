using GpLib.Domain.Abstractions;
using System;

namespace GpLib.Domain.Tests
{
    public class ValueAdded : DomainEvent<int>
    {
        private const int VERSION = 0;
        public double Value { get; set; }

        public ValueAdded(double value, int aggregateId, Guid guid) : base(aggregateId, guid, VERSION)
        {
            Value = value;
        }
    }
}
