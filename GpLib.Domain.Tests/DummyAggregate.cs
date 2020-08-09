using GpLib.Domain.Abstractions;
using System;
using System.Collections.Generic;

namespace GpLib.Domain.Tests
{
    public class DummyAggregate : AggregateRoot<int>
    {
        public int X { get; protected set; }

        public string Y { get; protected set; }

        public List<double> Values { get; protected set; }

        protected DummyAggregate() { }

        protected DummyAggregate(int x, string y)
        {
            ApplyEvent(new DummyAggregateCreated(x, y, Id, Guid.NewGuid()));
        }

        public static DummyAggregate Create(int x, string y) => new DummyAggregate(x, y);

        public static DummyAggregate CreateEmpty() => new DummyAggregate();

        public void AddValue(double v) => ApplyEvent(new ValueAdded(v, Id, Guid.NewGuid()));


        private void Apply(DummyAggregateCreated @event)
        {
            X = @event.X;
            Y = @event.Y;
            Values = new List<double>();
        }

        private void Apply(ValueAdded @event)
        {
            this.Values.Add(@event.Value);
        }

        protected override void ApplyChange<E>(E @event)
        {
            switch (@event)
            {
                case DummyAggregateCreated e:
                    Apply(e);
                    break;
                case ValueAdded e:
                    Apply(e);
                    break;
                default:
                    break;
            }
        }

    }
}
