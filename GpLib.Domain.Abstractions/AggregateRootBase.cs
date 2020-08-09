using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace GpLib.Domain.Abstractions
{
    public abstract class AggregateRootBase<TKey> : IAggregateRoot<TKey>
    {
 
        private ImmutableList<DomainEvent> _changes = ImmutableList<DomainEvent>.Empty;

        public TKey Id { get; protected set; }

        /// <summary>
        /// Applies an event to the current aggregate and adds it to the list of changes
        /// </summary>
        /// <param name="event"></param>
        protected AggregateRootBase<TKey> ApplyEvent(DomainEvent @event) =>
            Apply(@event, true);

        /// <summary>
        /// Gets the list of changes of the Aggregate as an immutable list
        /// </summary>
        /// <returns></returns>
        public List<DomainEvent> GetChanges() => _changes.ToList();

        /// <summary>
        /// Clears the saved changes 
        /// </summary>
        public void CommitChanges() => _changes = _changes.Clear();

        /// <summary>
        /// Dispatches between multiple concrete events
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="event">Domain-level event</param>
        protected abstract AggregateRootBase<TKey> ApplyChange(DomainEvent @event);

        private AggregateRootBase<TKey> Apply(DomainEvent @event, bool isNew)
        {
            if (isNew)
                _changes = _changes.Add(@event);

            return ApplyChange(@event);
        }


        public void LoadFromHistory(List<DomainEvent> history) => history.Aggregate(this, (acc, @event) => acc.Apply(@event, false));
    
    }
}
