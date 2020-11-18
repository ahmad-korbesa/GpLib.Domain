using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System;
using System.Reflection;

namespace GpLib.Domain.Abstractions
{
    public abstract class AggregateRoot<TKey> : IAggregateRoot<TKey>
    {
        protected AggregateRoot()
        {
            Version = 0;
        }

        private ImmutableList<DomainEvent<TKey>> _changes = ImmutableList<DomainEvent<TKey>>.Empty;

        public abstract TKey Id { get; protected set; }

        //Consider opening this name for modification
        private string EventApplicationMethodName { get; set; } = "Apply";

        public int Version { get; protected set; }

        private AggregateRoot<TKey> HandleEvent(DomainEvent<TKey> @event)
        {
            var mytype = this.GetType();
            var eventType = @event.GetType();

            var method = mytype
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .SingleOrDefault(p => p.ReturnType.Equals(mytype) &&
                                        p.Name == EventApplicationMethodName &&
                                        p.GetParameters().Single().ParameterType.Equals(eventType))
                ?? throw new AggregateRootException($"Could not find any {EventApplicationMethodName} method corresponding to the signature \"private/protected {mytype} {EventApplicationMethodName}({eventType})\"");

            return (AggregateRoot<TKey>)method.Invoke(this, new object[] { @event });
        }

        protected AggregateRoot<TKey> ApplyChange(DomainEvent<TKey> @event) => Apply(@event, true);

        /// <summary>
        /// Gets the list of changes of the Aggregate as an immutable list
        /// </summary>
        /// <returns></returns>
        public ICollection<DomainEvent<TKey>> GetChanges() => _changes.ToList();

        /// <summary>
        /// Clears the saved changes 
        /// </summary>
        public void CommitChanges() => _changes = _changes.Clear();


        private AggregateRoot<TKey> Apply(DomainEvent<TKey> @event, bool isNew)
        {
            if (isNew)
                _changes = _changes.Add(@event);
            Version++;
            return HandleEvent(@event);
        }


        public void LoadFromHistory(ICollection<DomainEvent<TKey>> history)
            => history.Aggregate(this,
                (acc, @event) => acc.Apply(@event, false));

    }
}
