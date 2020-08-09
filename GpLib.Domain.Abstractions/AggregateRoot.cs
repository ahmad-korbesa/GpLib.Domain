using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace GpLib.Domain.Abstractions
{
    public abstract class AggregateRoot<TKey>
    {
        /// <summary>
        /// defines the key type for the aggregate
        /// </summary>
        [JsonProperty]
        public TKey Id { get; protected set; }

        private ImmutableList<DomainEvent<TKey>> _changes;

        protected AggregateRoot() => _changes = ImmutableList<DomainEvent<TKey>>.Empty;

        /// <summary>
        /// Applies an event to the current aggregate and adds it to the list of changes
        /// </summary>
        /// <param name="event"></param>
        protected void ApplyEvent(DomainEvent<TKey> @event) => Apply(@event, true);

        private void Apply(DomainEvent<TKey> @event, bool isNew)
        {
            if (isNew)
                _changes = _changes.Add(@event);

            ApplyChange(@event);
        }


        /// <summary>
        /// Gets the list of changes of the Aggregate as an immutable list
        /// </summary>
        /// <returns></returns>
        public ImmutableList<DomainEvent<TKey>> GetChanges() => _changes;

        /// <summary>
        /// Clears the saved changes 
        /// </summary>
        public void CommitChanges() => _changes = _changes.Clear();

        /// <summary>
        /// Dispatches between multiple concrete events
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="event">Domain-level event</param>
        protected abstract void ApplyChange<E>(E @event) where E : DomainEvent<TKey>;

        /// <summary>
        /// Applies all the changes dictated by the input history list
        /// </summary>
        /// <param name="history">list of domain events </param>
        public void RebuildFromHistory(List<DomainEvent<TKey>> history) => history.ForEach(e => Apply(e, false));
    }
}
