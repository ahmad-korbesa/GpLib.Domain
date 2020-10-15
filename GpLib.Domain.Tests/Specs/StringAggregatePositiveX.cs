using GpLib.Domain.Abstractions;
using System;
using System.Linq.Expressions;

namespace GpLib.Domain.Tests.Specs
{
    public class StringAggregatePositiveX : SpecificationBase<StringKeyAggregate, string>
    {
        public override Expression<Func<StringKeyAggregate, bool>> SpecExpression => 
            aggr => aggr.X > 0;
    }
}
