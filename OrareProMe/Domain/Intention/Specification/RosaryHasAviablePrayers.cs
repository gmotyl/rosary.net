using System;
using System.Linq.Expressions;

namespace OrareProMe.Domain
{
    public class RosaryHasAviablePrayers : Specification<Rosary>
    {

        public override Expression<Func<Rosary, bool>> ToExpression()
        {
            return rosary => rosary.FreeMysteries.Count > 0;
        }

    }
}