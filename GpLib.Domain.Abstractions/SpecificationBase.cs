using System;
using System.Linq.Expressions;

namespace GpLib.Domain.Abstractions
{
    public abstract class SpecificationBase<T,TKey> : ISpecification<T, TKey> where T : AggregateRoot<TKey>
    {
        private Func<T, bool> _compiledExpression;

        private Func<T, bool> CompiledExpression
        {
            get { return _compiledExpression ??= SpecExpression.Compile(); }
        }

        public abstract Expression<Func<T, bool>> SpecExpression { get; }

        public bool IsSatisfiedBy(T obj)
        {
            return CompiledExpression(obj);
        }
    }
}
