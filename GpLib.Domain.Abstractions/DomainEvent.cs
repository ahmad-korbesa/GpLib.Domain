using Newtonsoft.Json;
using System;

namespace GpLib.Domain.Abstractions
{
    public abstract class DomainEvent<T>
    {
        protected DomainEvent(T aggregateId, Guid guid, int version)
        {
            AggregateId = aggregateId;
            Guid = guid;
            Version = version;
        }

        [JsonProperty]
        public T AggregateId { get; protected set; }

        [JsonProperty]
        public int Version { get; protected set; }

        [JsonProperty]
        public Guid Guid { get; protected set; }

    }
}
