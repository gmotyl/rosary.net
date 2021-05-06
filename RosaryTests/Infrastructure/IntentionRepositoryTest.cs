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
            var intention = new Intention("test intention");

            repository.Intentions.Add(intention);

            var expectedIntention = repository.Intentions.First(intention => intention.Title == "test intention");

            Assert.IsType<Intention>(expectedIntention);
            Assert.Equal<Intention>(intention, expectedIntention);

        }
    }
}
