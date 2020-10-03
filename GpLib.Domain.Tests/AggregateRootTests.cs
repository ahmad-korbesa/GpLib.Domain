using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace GpLib.Domain.Tests
{
    public class AggregateRootTests
    {
        [Fact]
        public void Should_AddEventToHistory()
        {
            var obj = StringKeyAggregate.Create("P12345", 1, "ahmad");
            obj.AddValue(3);
            obj.AddValue(5);
            var changes = obj.GetChanges();
            changes.Should().HaveCount(3);
            changes.ElementAt(0).Should().BeOfType(typeof(StringAggregateCreated));
            changes.ElementAt(1).Should().BeOfType(typeof(ValueAdded));
            changes.ElementAt(2).Should().BeOfType(typeof(ValueAdded));
            foreach (var item in changes)
            {
                item.AggregateId.Should().Be("P12345");
            }
        }

        [Fact]
        public void Should_NotAffectInnerChangesListWhenChangedAfterReturned()
        {
            var obj = StringKeyAggregate.Create("P12345", 1, "ahmad");
            obj.AddValue(3);
            obj.AddValue(5);
            var changes = obj.GetChanges();
            changes.Should().HaveCount(3);
            changes.Add(new ValueAdded(1, "P12345", Guid.NewGuid()));

            var changes2 = obj.GetChanges();
            changes2.Should().HaveCount(3);
            changes.Should().HaveCount(4);

        }



        [Fact]
        public void Should_RewindFromHistory()
        {
            var obj = StringKeyAggregate.Create("P12345", 1, "ahmad");
            obj.AddValue(3);
            obj.AddValue(5);
            var changes = obj.GetChanges();

            var newObj = StringKeyAggregate.CreateEmpty();
            newObj.LoadFromHistory(changes.ToList());
            newObj.Id.Should().Be(obj.Id);
            newObj.X.Should().Be(obj.X);
            newObj.Y.Should().Be(obj.Y);
            newObj.Values.Should().BeEquivalentTo(obj.Values);
        }
    }
}
