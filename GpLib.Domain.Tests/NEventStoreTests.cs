using FluentAssertions;
using GpLib.Domain.Abstractions;
using NEventStore;
using NEventStore.Serialization.Json;
using System;
using System.Linq;
using Xunit;

namespace GpLib.Domain.Tests
{
    public class NEventStoreTests
    {
        [Fact]
        public void Should_SaveStreamOfEvents()
        {

            var obj = StringKeyAggregate.Create("P12345", 1, "ahmad");
            obj.AddValue(3);
            obj.AddValue(5);
            var changes = obj.GetChanges();
            
            using var store = Wireup.Init().UsingInMemoryPersistence().UsingJsonSerialization().Build();

            using var stream = store.CreateStream(obj.Id);

            changes.Select(change => new EventMessage { Body = change })
                .ToList()
                .ForEach(change => stream.Add(change));

            stream.CommitChanges(Guid.NewGuid());


            using var streamOfEvents = store.OpenStream(obj.Id);
            var outputChanges = streamOfEvents.CommittedEvents.Select(x => x.Body as DomainEvent<string>).ToList();
            var emptyAggregate = StringKeyAggregate.CreateEmpty();
            emptyAggregate.LoadFromHistory(outputChanges);
            emptyAggregate.Id.Should().Be(obj.Id);

        }
    }
}
