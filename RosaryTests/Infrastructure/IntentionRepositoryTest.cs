using System;
using System.Linq;
using OrareProMe.Domain;
using OrareProMe.Infrastructure.Database;
using Xunit;


namespace OrareProMe.Infrastructure
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
