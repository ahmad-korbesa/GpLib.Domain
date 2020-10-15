using GpLib.Domain.Abstractions;
using System;

namespace GpLib.Domain.Tests
{
    public class StringAggregateMissingEvent : DomainEvent<string>
    {

        public StringAggregateMissingEvent(string aggregateId, Guid guid, int version) : base(aggregateId, guid, version)
        {
        }
    }
}
