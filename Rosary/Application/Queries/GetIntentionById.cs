using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rosary.Infrastructure;

namespace Rosary.Queries
{
    public sealed class GetIntentionById
    {
        // Query / Command
        // All the data we need to execute

        public class Query : IRequest<Response>
        {
            public Guid Id { get; }

            public Query(Guid id)
            {
                Id = id;
            }
        }

        // Handler
        // business logic to execute. Returns response

        public class Handler : IRequestHandler<Query, Response>
        {
            private IntentionRepository repository;
            public Handler(IntentionRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var intention = repository.Get(request.Id);
                return intention == null ? null : new Response(intention.Id, intention.Title, intention.Description);
            }
        }

        // Response
        // The data we want to return
        public class Response
        {
            public Guid Id { get; }
            public string Title { get; set; }
            public string Description { get; set; }

            public Response(Guid id, string title, string description)
            {
                Id = id;
                Title = title;
                Description = description;
            }
        }
    }
}