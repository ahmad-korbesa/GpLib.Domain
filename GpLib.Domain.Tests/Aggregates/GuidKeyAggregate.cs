using GpLib.Domain.Abstractions;
using System;
using System.Collections.Generic;

namespace GpLib.Domain.Tests
{
    public class GuidKeyAggregate : AggregateRoot<Guid>
    {
        public override Guid Id { get; protected set; }

        public int X { get; protected set; }

        public string Y { get; protected set; }

        public List<double> Values { get; protected set; }

        protected GuidKeyAggregate() { }

        protected GuidKeyAggregate(Guid id, int x, string y) =>
            ApplyChange(new GuidAggregateCreated(x, y, id, Guid.NewGuid()));

        public static GuidKeyAggregate Create(Guid id, int x, string y) => new GuidKeyAggregate(id, x, y);

        public static GuidKeyAggregate CreateEmpty() => new GuidKeyAggregate();

        public void AddValue(double v) => ApplyChange(new ValueAdded2(v, Id, Guid.NewGuid()));

        protected GuidKeyAggregate Apply(GuidAggregateCreated @event)
        {
            Id = @event.AggregateId;
            X = @event.X;
            Y = @event.Y;
            Values = new List<double>();
            return this;
        }

        protected GuidKeyAggregate Apply(ValueAdded2 @event)
        {
            Values.Add(@event.Value);
            return this;
        }
    }
}
