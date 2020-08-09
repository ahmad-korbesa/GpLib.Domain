using System;
using System.Linq.Expressions;

namespace GpLib.Domain.Abstractions
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> SpecExpression { get; }
        bool IsSatisfiedBy(T obj);
    }
}
