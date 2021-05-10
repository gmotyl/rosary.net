using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OrareProMe.Domain;
using OrareProMe.Infrastructure;

namespace OrareProMe.Commands
{
    public class AddIntention
    {
        public class Command : IRequest<Guid>
        {
            public string Title { get; set; }
            public string Description { get; set; }
        }

        public class Handler : IRequestHandler<Command, Guid>
        {

            private readonly IntentionRepository repository;

            public Handler(IntentionRepository repository)
            {
                this.repository = repository;
            }

            public Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                Intention intention = new Intention(request.Title);
                repository.Add(intention);

                return Task.FromResult(intention.Id);
            }
        }


    }
}