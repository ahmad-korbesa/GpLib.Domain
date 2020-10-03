using GpLib.Domain.Abstractions;
using System;
using System.Collections.Generic;

namespace GpLib.Domain.Tests
{
    public class StringKeyAggregate : AggregateRoot<string>
    { 
        public int X { get; protected set; }

        public string Y { get; protected set; }

        public List<double> Values { get; protected set; }

        protected StringKeyAggregate() { }

        protected StringKeyAggregate(string id, int x, string y) =>
            ApplyEvent(new StringAggregateCreated(x, y, id, Guid.NewGuid()));
      
        public static StringKeyAggregate Create(string id, int x, string y) => new StringKeyAggregate(id, x, y);

        public static StringKeyAggregate CreateEmpty() => new StringKeyAggregate();

        public StringKeyAggregate AddValue(double v) => ApplyEvent(new ValueAdded(v, Id, Guid.NewGuid())) as StringKeyAggregate;

        private StringKeyAggregate Apply(StringAggregateCreated @event)
        {
            Id = @event.AggregateId;
            X = @event.X;
            Y = @event.Y;
            Values = new List<double>();
            return this;
        }

        private StringKeyAggregate Apply(ValueAdded @event)
        {
            Values.Add(@event.Value);
            return this;
        }

        protected override AggregateRoot<string> ApplyChange(DomainEvent<string> @event) => @event switch
        {
            StringAggregateCreated e => Apply(e),
            ValueAdded e => Apply(e),
            _ => throw new Exception("Unknown event")
        };
      
    }
}
