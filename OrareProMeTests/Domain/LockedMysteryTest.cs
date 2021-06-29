using System;
using FluentAssertions;
using Xunit;

namespace OrareProMe.Domain
{
    public class LockedMysteryTest
    {
        [Fact]
        public void New_lockMystery_isLocked()
        {
            var lockedMystery = new LockedMystery(Mystery.Joyful1);

            lockedMystery.IsLocked().Should().BeTrue();
        }

        [Fact]
        public void LockMystery_isLocked_expires()
        {
            int numberOfCalls = 0;

            Func<DateTime> mockedTime = () => {
                if (++numberOfCalls > 1)
                    return DateTime.UtcNow.AddMinutes(12); // current time
                else
                    return DateTime.UtcNow; // lock time
            };

            var lockedMystery = new LockedMystery(Mystery.Joyful1, mockedTime);
            lockedMystery.IsLocked().Should().BeFalse();
        }
    }
}