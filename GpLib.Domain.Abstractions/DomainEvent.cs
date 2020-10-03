using Newtonsoft.Json;
using System;

namespace GpLib.Domain.Abstractions
{
    public abstract class DomainEvent<TAggregateKey>
    {
        protected DomainEvent(TAggregateKey aggregateId, Guid guid, int version)
        {
            AggregateId = aggregateId;
            Guid = guid;
            Version = version;
        }
        [JsonProperty]
        public TAggregateKey AggregateId { get; protected set; }

        [JsonProperty]
        public int Version { get; protected set; }

        [JsonProperty]
        public Guid Guid { get; protected set; }
    }
}
