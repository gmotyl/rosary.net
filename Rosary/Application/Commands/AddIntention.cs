using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rosary.Domain;
using Rosary.Infrastructure;

namespace Rosary.Commands
{
    public class AddIntention
    {
        public class Command : IRequest<int>
        {
            public string Title { get; set; }
            public string Description { get; set; }
        }

        public class Handler : IRequestHandler<Command, int>
        {

            private readonly IntentionRepository repository;

            public Handler(IntentionRepository repository)
            {
                this.repository = repository;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                repository.Intentions.Add(new Intention(9, request.Title));
                return 9;
            }
        }


    }
}