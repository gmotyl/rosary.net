using System;
using System.Linq;
using Rosary.Domain;
using Xunit;

namespace Rosary.Infrastructure
{
    public class IntentionRepositoryTest
    {
        [Fact]
        public void ShouldReturnIntentions()
        {
            var repository = new IntentionRepository();
            var count = repository.Intentions.Count;

            Assert.NotEmpty(repository.Intentions);
        }

        [Fact]
        public void ShouldAddIntention()
        {
            var repository = new IntentionRepository();
            var intention = new Intention(99, "test intention");

            repository.Intentions.Add(intention);

            var expectedIntention = repository.Intentions.First(intention => intention._id == 99);

            Assert.IsType<Intention>(expectedIntention);
            Assert.Equal<Intention>(intention, expectedIntention);

        }
    }
}
