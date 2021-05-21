using System;
using System.Linq.Expressions;
using OrareProMe.Domain.Intention;

namespace OrareProMe.Domain.Specification
{
    public class RosaryHasAviablePrayers : Specification<Rosary>
    {

        public override Expression<Func<Rosary, bool>> ToExpression()
        {
            return rosary => rosary.Prayers.Count < 20;
        }

    }
}