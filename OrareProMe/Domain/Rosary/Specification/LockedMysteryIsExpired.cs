using System;
using System.Linq.Expressions;

namespace OrareProMe.Domain
{
    public class LockedMysteryIsExpired : Specification<LockedMystery>
    {

        public override Expression<Func<LockedMystery, bool>> ToExpression()
        {
            return lMystery => !lMystery.IsLocked();
        }

    }
}