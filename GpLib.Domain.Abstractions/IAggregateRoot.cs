namespace GpLib.Domain.Abstractions
{
    public interface IAggregateRoot<out TKey>
    {
        TKey Id { get; }
    }
}
