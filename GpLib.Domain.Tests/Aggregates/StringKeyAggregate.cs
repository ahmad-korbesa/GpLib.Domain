using GpLib.Domain.Abstractions;
using System;
using System.Collections.Generic;

namespace GpLib.Domain.Tests
{
    public class StringKeyAggregate : AggregateRoot<string>
    { 
        public override string Id { get; protected set; }

        public int X { get; protected set; }

        public string Y { get; protected set; }

        public List<double> Values { get; protected set; }

        protected StringKeyAggregate() { }

        protected StringKeyAggregate(string id, int x, string y) =>
            ApplyChange(new StringAggregateCreated(x, y, id, Guid.NewGuid()));
      
        public static StringKeyAggregate Create(string id, int x, string y) => new StringKeyAggregate(id, x, y);

        public static StringKeyAggregate CreateEmpty() => new StringKeyAggregate();

        public StringKeyAggregate AddValue(double v) => ApplyChange(new ValueAdded(v, Id, Guid.NewGuid())) as StringKeyAggregate;

        public void InvokeMissingEvent()
        {
            ApplyChange(new StringAggregateMissingEvent(Id, Guid.NewGuid(), 0));
        }

        protected StringKeyAggregate Apply(StringAggregateCreated @event)
        {
            Id = @event.AggregateId;
            X = @event.X;
            Y = @event.Y;
            Values = new List<double>();
            return this;
        }

        protected StringKeyAggregate Apply(ValueAdded @event)
        {
            Values.Add(@event.Value);
            return this;
        }

      
    }
}
