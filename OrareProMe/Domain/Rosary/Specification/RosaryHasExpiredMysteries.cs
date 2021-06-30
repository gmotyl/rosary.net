using System;
using System.Linq;
using System.Linq.Expressions;

namespace OrareProMe.Domain
{
    public class RosaryHasExpiredMysteries : Specification<Rosary>
    {

        public override Expression<Func<Rosary, bool>> ToExpression()
        {
            var predicate = new LockedMysteryIsExpired();
            return rosary => rosary.LockedMysteries.Any(predicate.IsSatisfiedBy);
        }

    }
}