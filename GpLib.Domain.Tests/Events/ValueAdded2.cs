using GpLib.Domain.Abstractions;
using System;

namespace GpLib.Domain.Tests
{
    public class ValueAdded2 : DomainEvent<Guid>
    {
        private const int VERSION = 0;
        public double Value { get; set; }

        public ValueAdded2(double value, Guid aggregateId, Guid guid) : base(aggregateId, guid, VERSION)
        {
            Value = value;
        }
    }
}
