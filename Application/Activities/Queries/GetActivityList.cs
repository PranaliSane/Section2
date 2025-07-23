using System;
using System.Diagnostics;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistance;

namespace Application.Activities.Queries;

public class GetActivityList
{
    public class Query : IRequest<List<Domain.Activity>> { }

    public class Handler(AppDbContext context) : IRequestHandler<Query, List<Domain.Activity>>
    {
        public async Task<List<Domain.Activity>> Handle(Query request, CancellationToken cancellationToken)
        {
        
            return await context.Activities.ToListAsync(cancellationToken);
        }
    }
}
