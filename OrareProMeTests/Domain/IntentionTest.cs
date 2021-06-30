using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace OrareProMe.Domain
{
    public class IntentionTest
    {

        [Fact]
        public void Intention_reserves_prayers_with_rosary()
        {
            var user = new User();
            var intention = new Intention("test", "test", user);
            var prayer = intention.ReservePrayer(user.Id);

            prayer.Rosary.Should().NotBe(null);
            prayer.Rosary.Should().BeOfType<Rosary>();
        }

        [Fact]
        public void New_intention_reserves_20_prayers_from_the_same_rosary()
        {
            var user = new User();
            var intention = new Intention("test", "test", user);
            var prayerList = new List<Prayer>();
            var firstPrayer = intention.ReservePrayer(user.Id);

            for (int i = 1; i < 20; i++)
            {
                prayerList.Add(intention.ReservePrayer(user.Id));
            }

            var nextRosaryPrayer = intention.ReservePrayer(user.Id);

            foreach (var prayer in prayerList)
            {
                prayer.Rosary.Should().Be(firstPrayer.Rosary);
            }
            nextRosaryPrayer.Rosary.Should().NotBe(firstPrayer.Rosary);
        }

        [Fact]
        public void Reserves_expired_mystery_first()
        {
            var user = new User();
            var intention = new Intention("test", "test", user);
            Rosary rosary = intention.Rosaries.First();

            foreach (var m in Enum.GetValues(typeof(Mystery)).Cast<Mystery>())
            {
                if (m != Mystery.Luminous1 && m != Mystery.Empty) {
                    rosary.Finish(m);
                }
            }

            int numberOfCalls = 0;

            Func<DateTime> mockedTime = () => {
                if (++numberOfCalls > 1)
                    return DateTime.UtcNow.AddMinutes(12); // current time
                else
                    return DateTime.UtcNow; // lock time
            };            

            var expiredPrayer = intention.ReservePrayer(user.Id, mockedTime);
            var nextPrayer = intention.ReservePrayer(user.Id);

            expiredPrayer.Mystery.Should().Be(Mystery.Luminous1);
            nextPrayer.Mystery.Should().Be(Mystery.Luminous1);

        }
    }
}