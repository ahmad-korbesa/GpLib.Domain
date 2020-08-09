using Xunit;

namespace GpLib.Domain.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Should_AddEventToHistory()
        {
            var obj = DummyAggregate.Create(1, "ahmad");

        }
    }
}
