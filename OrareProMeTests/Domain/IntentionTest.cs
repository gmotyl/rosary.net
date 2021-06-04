using System.Collections.Generic;
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
    }
}