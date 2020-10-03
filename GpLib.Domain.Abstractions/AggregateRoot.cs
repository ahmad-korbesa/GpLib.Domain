using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace GpLib.Domain.Abstractions
{
    public abstract class AggregateRoot<TKey> : IAggregateRoot<TKey>
    {
 
        private ImmutableList<DomainEvent<TKey>> _changes = ImmutableList<DomainEvent<TKey>>.Empty;

        public TKey Id { get; protected set; }

        /// <summary>
        /// Applies an event to the current aggregate and adds it to the list of changes
        /// </summary>
        /// <param name="event"></param>
        protected AggregateRoot<TKey> ApplyEvent(DomainEvent<TKey> @event) =>
            Apply(@event, true);

        /// <summary>
        /// Gets the list of changes of the Aggregate as an immutable list
        /// </summary>
        /// <returns></returns>
        public ICollection<DomainEvent<TKey>> GetChanges() => _changes.ToList();

        /// <summary>
        /// Clears the saved changes 
        /// </summary>
        public void CommitChanges() => _changes = _changes.Clear();

        /// <summary>
        /// Dispatches between multiple concrete events
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="event">Domain-level event</param>
        protected abstract AggregateRoot<TKey> ApplyChange(DomainEvent<TKey> @event);

        private AggregateRoot<TKey> Apply(DomainEvent<TKey> @event, bool isNew)
        {
            if (isNew)
                _changes = _changes.Add(@event);
            return ApplyChange(@event);
        }


        public void LoadFromHistory(ICollection<DomainEvent<TKey>> history) 
            => history.Aggregate(this, 
                (acc, @event) => acc.Apply(@event, false));
    
    }
}
