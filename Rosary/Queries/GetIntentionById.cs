using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rosary.Database;

namespace Rosary.Queries
{
    public sealed class GetIntentionById
    {
        // Query / Command
        // All the data we need to execute

        public class Query : IRequest<Response>
        {
            public int Id { get; }

            public Query(int id)
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
                var intention = repository.Intentions.FirstOrDefault(x => x._id == request.Id);
                return intention == null ? null : new Response(intention._id, intention.Title, intention.Description);
            }
        }

        // Response
        // The data we want to return
        public class Response
        {
            public int Id { get; }
            public string Title { get; set; }
            public string Description { get; set; }

            public Response(int id, string title, string description)
            {
                Id = id;
                Title = title;
                Description = description;
            }
        }
    }
}