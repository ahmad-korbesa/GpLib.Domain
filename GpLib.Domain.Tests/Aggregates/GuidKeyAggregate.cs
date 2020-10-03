using GpLib.Domain.Abstractions;
using System;
using System.Collections.Generic;

namespace GpLib.Domain.Tests
{
    public class GuidKeyAggregate : AggregateRoot<Guid>
    {
        public int X { get; protected set; }

        public string Y { get; protected set; }

        public List<double> Values { get; protected set; }

        protected GuidKeyAggregate() { }

        protected GuidKeyAggregate(Guid id, int x, string y) =>
            ApplyEvent(new GuidAggregateCreated(x, y, id, Guid.NewGuid()));

        public static GuidKeyAggregate Create(Guid id, int x, string y) => new GuidKeyAggregate(id, x, y);

        public static GuidKeyAggregate CreateEmpty() => new GuidKeyAggregate();

        public void AddValue(double v) => ApplyEvent(new ValueAdded2(v, Id, Guid.NewGuid()));

        private GuidKeyAggregate Apply(GuidAggregateCreated @event)
        {
            Id = @event.AggregateId;
            X = @event.X;
            Y = @event.Y;
            Values = new List<double>();
            return this;
        }

        private GuidKeyAggregate Apply(ValueAdded2 @event)
        {
            Values.Add(@event.Value);
            return this;
        }
        protected override AggregateRoot<Guid> ApplyChange(DomainEvent<Guid> @event) => @event switch
        {
            GuidAggregateCreated e => Apply(e),
            ValueAdded2 e => Apply(e),
            _ => throw new Exception("Unknown event")
        };
    }
}
