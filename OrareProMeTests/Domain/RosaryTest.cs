using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace OrareProMe.Domain
{
    public class RosaryTest
    {
        [Fact]
        public void New_Rosary_Has_21_Free_Mysteries()
        {
            Rosary rosary = new Rosary();

            rosary.FreeMysteries.Count().Should().Be(21);
            rosary.FinishedMysteries.Count().Should().Be(0);
            rosary.LockedMysteries.Count().Should().Be(1); // Empty Mystery
        }

        [Fact]
        public void Prayer_Reservation_Changes_Counters()
        {
            Rosary rosary = new Rosary();

            rosary.NextMystery();

            rosary.FreeMysteries.Count().Should().Be(20);
            rosary.FinishedMysteries.Count().Should().Be(0);
            rosary.LockedMysteries.Count().Should().Be(2); // Empty Mystery + 1

            rosary.NextMystery();
            rosary.NextMystery();
            rosary.NextMystery();
            rosary.NextMystery();

            rosary.FreeMysteries.Count().Should().Be(16);
            rosary.FinishedMysteries.Count().Should().Be(0);
            rosary.LockedMysteries.Count().Should().Be(6);
        }

        [Fact]
        public void Two_rosaries_not_equal_even_if_they_have_the_same_pray_sequence()
        {
            Rosary rosary1 = new Rosary();
            Rosary rosary2 = new Rosary();

            rosary1.NextMystery();
            rosary1.NextMystery();
            rosary2.NextMystery();
            rosary2.NextMystery();

            rosary1.Should().NotBe(rosary2);
        }

        [Fact]
        public void Two_rosaries_dont_equal_if_they_have_diffrent_pray_sequence()
        {
            Rosary rosary1 = new Rosary();
            Rosary rosary2 = new Rosary();

            rosary1.NextMystery();
            rosary2.NextMystery();
            rosary2.NextMystery();
            rosary2.NextMystery();

            rosary1.Should().NotBe(rosary2);
        }

        [Fact]
        public void NextMystery_Returns_Proper_sequence()
        {
            Rosary rosary = new Rosary();

            Mystery mystery1 = rosary.NextMystery();
            Mystery mystery2 = rosary.NextMystery();
            Mystery mystery3 = rosary.NextMystery();
            Mystery mystery4 = rosary.NextMystery();
            Mystery mystery5 = rosary.NextMystery();
            Mystery mystery6 = rosary.NextMystery();
            Mystery mystery7 = rosary.NextMystery();
            Mystery mystery8 = rosary.NextMystery();
            Mystery mystery9 = rosary.NextMystery();
            Mystery mystery10 = rosary.NextMystery();
            Mystery mystery11 = rosary.NextMystery();
            rosary.NextMystery();
            rosary.NextMystery();
            rosary.NextMystery();
            rosary.NextMystery();

            Mystery mystery16 = rosary.NextMystery();
            rosary.NextMystery();
            rosary.NextMystery();
            rosary.NextMystery();
            Mystery mystery20 = rosary.NextMystery();


            mystery1.Should().Be(Mystery.Joyful1);
            mystery2.Should().Be(Mystery.Joyful2);
            mystery3.Should().Be(Mystery.Joyful3);
            mystery4.Should().Be(Mystery.Joyful4);
            mystery5.Should().Be(Mystery.Joyful5);
            mystery6.Should().Be(Mystery.Luminous1);
            mystery7.Should().Be(Mystery.Luminous2);
            mystery8.Should().Be(Mystery.Luminous3);
            mystery9.Should().Be(Mystery.Luminous4);
            mystery10.Should().Be(Mystery.Luminous5);
            mystery11.Should().Be(Mystery.Sorrowful1);
            mystery16.Should().Be(Mystery.Glorious1);
            mystery20.Should().Be(Mystery.Glorious5);
            rosary.LockedMysteries.Count().Should().Be(21);

        }

        [Fact]
        public void NextMystery_Returns_expired_mystery()
        {
            int numberOfCalls = 0;

            Func<DateTime> mockedTime = () => {
                if (++numberOfCalls > 1)
                    return DateTime.UtcNow.AddMinutes(15); // current time
                else
                    return DateTime.UtcNow; // lock time
            };

            Rosary rosary = new Rosary();

            Mystery mystery01 = rosary.NextMystery(); // Joyful1
            Mystery mystery02 = rosary.NextMystery(); // Joyful2
            Mystery mystery1 = rosary.NextMystery(mockedTime); // Joyful3 expire...
            Mystery mystery2 = rosary.NextMystery(mockedTime); // Joyful3
            Mystery mystery3 = rosary.NextMystery(mockedTime); // Joyful4

            mystery2.Should().Be(mystery1);
            mystery3.Should().Be(Mystery.Joyful4);
        }

    }
}